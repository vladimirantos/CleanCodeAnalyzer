using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner;
using Cleaner.Comparator;

namespace CleanCodeAnalyzer
{
    class DataGridBinder
    {
        private List<CcaResult> _data;

        public DataGridBinder(List<CcaResult> results)
        {
            _data = results.OrderByDescending(x => x.Errors.Score()).ToList();
        }

        public List<object> GetData()
        {
            List<object> result = new List<object>();
            foreach (var d in _data)
            {
                result.Add(new
                {
                    ClassName = d.Class.Header.Name,
                    Names = $"{d.Errors.NamesLength} / {d.Errors.CorrectNames}",
                    NameLength = d.Errors.NamesLength,
                    CorrectNames = d.Errors.CorrectNames,
                    CodeLines = d.Errors.CodeLines,
                    CommentLines = d.Errors.CommentLines,
                    WhitespaceLines = d.Errors.WhitespaceLines,
                    PropertiesVariables = $"{d.Errors.CountVariables} / {d.Errors.CountProperties}",
                    Variables = d.Errors.CountVariables,
                    Properties = d.Errors.CountProperties,
                    MethodsArgs = $"{d.Errors.CountMethods} / {d.Errors.CountArgs}",
                    CountMethods = d.Errors.CountMethods,
                    SimilarityMethods = d.Errors.SimilarityMethods,
                    CountArgs = d.Errors.CountArgs,
                    CyclomaticComplx = d.Errors.CyclomaticComplx
                });
            }
            return result;
        }
    }
}
