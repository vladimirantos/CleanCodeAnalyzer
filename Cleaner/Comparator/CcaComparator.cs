using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.Statistics;
using Cleaner.Utils;

namespace Cleaner.Comparator
{
    public interface IComparator
    {
        List<CcaResult> Results { get; }

        void Compare(List<ClassStatistics> statistics);
    }

    class CcaComparator : IComparator
    {
        private readonly ConfigurationReader _configurationReader;

        public List<CcaResult> Results { get; } = new List<CcaResult>();

        public CcaComparator(string configurationDataPath)
        {
            try
            {
                _configurationReader = ConfigurationFile.Reader(configurationDataPath);
            }
            catch (InvalidOperationException ex)
            {
                throw new CcaException("Configuration file is empty.", ex);
            }
            catch (FileNotFoundException ex)
            {
                throw new CcaException("Configuration file dont exist", ex);
            }
        }

        public void Compare(List<ClassStatistics> statistics)
        {
            statistics.ForEach(classStatistic =>
            {
                CcaResult result = new CcaResult(classStatistic.CcaClass);

                if (Compare("CLASS_NAME_LENGTH", classStatistic.NameLength))
                    result.Errors.NamesLength++;

                if (!classStatistic.IsCorrectName)
                    result.Errors.CorrectNames++;

                if (Compare("CLASS_CODE_LINES", classStatistic.CodeLength.Length))
                    result.Errors.CodeLines++;

                if (Compare("CLASS_COMMENTS_LINES", classStatistic.CodeLength.CommentsCount))
                    result.Errors.CommentLines++;

                if (Compare("CLASS_WHITESPACE_LINES", classStatistic.CodeLength.WhitespaceCount))
                    result.Errors.WhitespaceLines++;

                if (Compare("COUNT_VARIABLES", classStatistic.CountVariables))
                    result.Errors.CountVariables++;

                if (Compare("COUNT_PROPERTIES", classStatistic.CountProperties))
                    result.Errors.CountProperties++;

                if (Compare("COUNT_METHODS", classStatistic.CountMethods))
                    result.Errors.CountMethods++;

                if (Compare("COUNT_SIMILARITY_METHODS", classStatistic.SimilarityMethods))
                    result.Errors.SimilarityMethods++;

                CompareMethods(classStatistic.MethodStatistics, ref result);
                CompareProperties(classStatistic.PropertyStatistics, ref result);
                CompareVariables(classStatistic.VariableStatistics, ref result);
                Results.Add(result);
            });
        }

        private bool Compare(string key, int value)
        {
            try
            {
                return value > _configurationReader.Get(key);
            }
            catch (ArgumentException ex)
            {
                throw new CcaException("An error occurred while reading the configuration file.", ex);
            }
        } 

        private void CompareMethods(List<MethodStatistic> methodStatistics, ref CcaResult result)
        {
            foreach (var methodStatistic in methodStatistics)
            {
                if (Compare("METHOD_NAME_LENGTH", methodStatistic.NameLength))
                    result.Errors.NamesLength++;

                if (!methodStatistic.IsCorrectName)
                    result.Errors.CorrectNames++;

                if (Compare("METHOD_CODE_LINES", methodStatistic.CodeLength.Length))
                    result.Errors.CodeLines++;

                if (Compare("METHOD_COMMENTS_LINES", methodStatistic.CodeLength.CommentsCount))
                    result.Errors.CommentLines++;

                if (Compare("METHOD_WHITESPACE_LINES", methodStatistic.CodeLength.WhitespaceCount))
                    result.Errors.WhitespaceLines++;

                if (Compare("METHOD_COUNT_ARGS", methodStatistic.CountArguments))
                    result.Errors.CountArgs++;

                if (Compare("CYCLOMATIC_COMPLX", methodStatistic.CyclomaticComplexity))
                    result.Errors.CyclomaticComplx++;
            } 
        }

        private void CompareProperties(List<PropertyStatistic> properties, ref CcaResult result)
        {
            foreach (var property in properties)
            {
                if (Compare("PROP_NAME_LENGTH", property.NameLength))
                    result.Errors.NamesLength++;
                if (!property.IsCorrectName)
                    result.Errors.CorrectNames++;
            }
        }

        private void CompareVariables(List<VariableStatistics> variables, ref CcaResult result)
        {
            foreach (var variable in variables)
            {
                if (Compare("VAR_NAME_LENGTH", variable.NameLength))
                    result.Errors.NamesLength++;
                if (!variable.IsCorrectName)
                    result.Errors.CorrectNames++;
            }
        }
    }
}
