using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Comparator;

namespace CleanCodeAnalyzer
{
    class DataGridBinder
    {
        private List<Result> _data;

        public DataGridBinder(List<Result> results)
        {
            _data = results;
        }

        public List<object> GetData()
        {
            List<object> result = new List<object>();
            foreach (var d in _data)
            {
                result.Add(new
                {
                    ClassName = d.Class.Header.Name,
                    Names = $"{d.Errors["NAME_LENGTH"]} / {d.Errors["CORRECT_NAMES"]}",
                    NameLength = d.Errors["NAME_LENGTH"],
                    CorrectNames = d.Errors["CORRECT_NAMES"],
                    CodeLines = d.Errors["CODE_LINES"],
                    CommentLines = d.Errors["COMMENTS_LINES"],
                    WhitespaceLines = d.Errors["WHITESPACE_LINES"],
                    PropertiesVariables = $"{d.Errors["COUNT_VARIABLES"]} / {d.Errors["COUNT_PROPERTIES"]}",
                    Variables = d.Errors["COUNT_VARIABLES"],
                    Properties = d.Errors["COUNT_PROPERTIES"],
                    MethodsArgs = $"{d.Errors["COUNT_METHODS"]} / {d.Errors["COUNT_ARGS"]}",
                    CountMethods = d.Errors["COUNT_METHODS"],
                    SimilarityMethods = d.Errors["SIMILARITY_METHODS"],
                    CountArgs = d.Errors["COUNT_ARGS"],
                    CyclomaticComplx = d.Errors["CYCLOMATIC_COMPLX"]
                });
            }
            return result;
        }
    }
}
