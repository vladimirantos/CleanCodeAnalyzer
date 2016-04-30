﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.Statistics;
using Cleaner.Utils;

namespace Cleaner.Comparator
{
    class CcaComparator
    {
        private readonly ConfigurationReader _configurationReader;
        private readonly List<ClassStatistics> _statistics;

        public List<Result> Results { get; } = new List<Result>();

        public CcaComparator(List<ClassStatistics> statistics, string configurationDataPath)
        {
            _statistics = statistics;
            _configurationReader = ConfigurationFile.Reader(configurationDataPath);
        }

        public void Compare()
        {
            _statistics.ForEach(classStatistic =>
            {
                Result result = new Result(classStatistic.CcaClass);

                if (Compare("CLASS_NAME_LENGTH", classStatistic.NameLength))
                    result.AddError("NAME_LENGTH");

                if (!classStatistic.IsCorrectName)
                    result.AddError("CORRECT_NAMES");

                if(Compare("CLASS_CODE_LINES", classStatistic.CodeLength.Length))
                    result.AddError("CODE_LINES");

                if(Compare("CLASS_COMMENTS_LINES", classStatistic.CodeLength.CommentsCount))
                    result.AddError("COMMENTS_LINES");

                if(Compare("CLASS_WHITESPACE_LINES", classStatistic.CodeLength.WhitespaceCount))
                    result.AddError("WHITESPACE_LINES");

                if (Compare("COUNT_VARIABLES", classStatistic.CountVariables))
                    result.AddError("COUNT_VARIABLES");

                if(Compare("COUNT_PROPERTIES", classStatistic.CountProperties))
                    result.AddError("COUNT_PROPERTIES");

                if(Compare("COUNT_METHODS", classStatistic.CountMethods))
                    result.AddError("COUNT_METHODS");

                if(Compare("COUNT_SIMILARITY_METHODS", classStatistic.SimilarityMethods))
                    result.AddError("SIMILARITY_METHODS");

                CompareMethods(classStatistic.MethodStatistics, ref result);
                CompareProperties(classStatistic.PropertyStatistics, ref result);
                CompareVariables(classStatistic.VariableStatistics, ref result);
                Results.Add(result);
            });
        }

        private bool Compare(string key, int value) => value > _configurationReader.Get(key);

        private void CompareMethods(List<MethodStatistic> methodStatistics, ref Result result)
        {
            foreach (var methodStatistic in methodStatistics)
            {
                if (Compare("METHOD_NAME_LENGTH", methodStatistic.NameLength))
                    result.AddError("NAME_LENGTH");

                if (!methodStatistic.IsCorrectName)
                    result.AddError("CORRECT_NAMES");

                if(Compare("METHOD_CODE_LINES", methodStatistic.CodeLength.Length))
                    result.AddError("CODE_LINES");

                if(Compare("METHOD_COMMENTS_LINES", methodStatistic.CodeLength.CommentsCount))
                    result.AddError("COMMENTS_LINES");

                if(Compare("METHOD_WHITESPACE_LINES", methodStatistic.CodeLength.WhitespaceCount))
                    result.AddError("WHITESPACE_LINES");

                if(Compare("METHOD_COUNT_ARGS", methodStatistic.CountArguments))
                    result.AddError("COUNT_ARGS");

                if(Compare("CYCLOMATIC_COMPLX", methodStatistic.CyclomaticComplexity))
                    result.AddError("CYCLOMATIC_COMPLX");
            } 
        }

        private void CompareProperties(List<PropertyStatistic> properties, ref Result result)
        {
            foreach (var property in properties)
            {
                if(Compare("PROP_NAME_LENGTH", property.NameLength))
                    result.AddError("NAME_LENGTH");
                if(!property.IsCorrectName)
                    result.AddError("CORRECT_NAMES");
            }
        }

        private void CompareVariables(List<VariableStatistics> variables, ref Result result)
        {
            foreach (var variable in variables)
            {
                if(Compare("VAR_NAME_LENGTH", variable.NameLength))
                    result.AddError("NAME_LENGTH");
                if (!variable.IsCorrectName)
                    result.AddError("CORRECT_NAMES");
            }
        }
    }
}
