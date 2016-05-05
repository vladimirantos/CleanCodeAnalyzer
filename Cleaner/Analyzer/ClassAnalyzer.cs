using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.Tools;
using Cleaner.Analyzer.Statistics;
using Cleaner.Entity;

namespace Cleaner.Analyzer
{
    internal class ClassAnalyzer
    {
        private readonly CcaClass _class;

        public ClassAnalyzer(CcaClass @class)
        {
            _class = @class;
        }

        public ClassStatistics Analyze()
        {
            ClassStatistics statistics = new ClassStatistics()
            {
                CcaClass = _class,
                NameLength = _class.Header.Name.Length,
                IsCorrectName = Names.IsCorrect(_class.Header.Name),
                CountVariables = _class.Variables.Count,
                CountProperties = _class.Properties.Count,
                CountMethods = _class.Methods.Count,
                CodeLength = (CodeLengthStatistics)CodeLength.Analyze(_class.Content),
                SimilarityMethods = (int)SimilarityMethods.Analyze(_class.Methods),
                MethodStatistics = MethodStatistics(_class.Methods, _class),
                PropertyStatistics = PropertyStatistics(_class.Properties),
                VariableStatistics = VariableStatistics(_class.Variables)
            };
            
            return statistics;
        }

        private List<MethodStatistic> MethodStatistics(List<CcaMethod> methods, CcaClass _class)
        {
            List<MethodStatistic> result = new List<MethodStatistic>();
            methods.ForEach(method =>
            {
                var c = _class;
                result.Add(new MethodStatistic()
                {
                    Method = method,
                    NameLength = method.Name.Length,
                    IsCorrectName = Names.IsCorrect(method.Name),
                    CodeLength = (CodeLengthStatistics)CodeLength.Analyze(method.Body?.ToString()),
                    CountArguments = method.Arguments.Count
                });
            });
            return result;
        }

        private List<PropertyStatistic> PropertyStatistics(List<CcaProperty> properties)
        {
            List<PropertyStatistic> result = new List<PropertyStatistic>();
            properties.ForEach(property =>
            {
                result.Add(new PropertyStatistic()
                {
                    NameLength = property.Name.Length,
                    IsCorrectName = Names.IsCorrectPropertyName(property.Name, property.DataType),
                    CodeLength = (CodeLengthStatistics)CodeLength.Analyze(property.Content)
                });
            });
            return result;
        }

        private List<VariableStatistics> VariableStatistics(List<Field> variables)
        {
            List<VariableStatistics> result = new List<VariableStatistics>();
            variables.ForEach(variable =>
            {
                result.Add(new VariableStatistics()
                {
                    NameLength = variable.Name.Length,
                    IsCorrectName = Names.IsCorrectVariableName(variable.Name, variable.DataType)
                });
            });
            return result;
        } 
    }
}
