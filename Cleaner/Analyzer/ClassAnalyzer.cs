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
    class ClassAnalyzer
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
                CountVariables = _class.Variables.Count,
                CountProperties = _class.Properties.Count,
                CountMethods = _class.Methods.Count,
                CodeLength = (CodeLengthStatistics)CodeLength.Analyze(_class.Content),
                SimilarityMethods = (int)SimilarityMethods.Analyze(_class.Methods),
                MethodStatistic = MethodStatistics(_class.Methods)
            };
            
            return statistics;
        }

        private List<MethodStatistic> MethodStatistics(List<CcaMethod> methods)
        {
            List<MethodStatistic> result = new List<MethodStatistic>();
            methods.ForEach(method =>
            {
                result.Add(new MethodStatistic()
                {
                    CodeLength = (CodeLengthStatistics)CodeLength.Analyze(method.Body.ToString()),
                    CountArguments = method.Arguments.Count
                });
            });
            return result;
        }
    }
}
