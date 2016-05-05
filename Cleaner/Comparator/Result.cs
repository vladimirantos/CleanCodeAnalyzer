using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;

namespace Cleaner.Comparator
{
    public class Result
    {
        private static readonly List<string> MetricNames = new List<string>() { "NAME_LENGTH", "CORRECT_NAMES", "CODE_LINES", "COMMENTS_LINES",
            "WHITESPACE_LINES", "COUNT_VARIABLES", "COUNT_PROPERTIES", "COUNT_METHODS", "SIMILARITY_METHODS", "COUNT_ARGS", "CYCLOMATIC_COMPLX" };
        public CcaClass Class { get; }
        public Dictionary<string, int> Errors { get; private set; }

        public Result(CcaClass @class)
        {
            Class = @class;
            Errors = InitialErrors();
        }

        /// <summary>
        /// Zvýší počet chyb zadaného klíče o 1. Pokud klíč neexistuje, bude automaticky vytvořen.
        /// </summary>
        public void AddError(string key)
        {
            int value;
            if (Errors.TryGetValue(key, out value))
                Errors[key] = value + 1;
            else Errors.Add(key, 1);
        }

        private static Dictionary<string, int> InitialErrors()
        {
            Dictionary<string, int> errors = new Dictionary<string, int>();
            foreach (var metricName in MetricNames)
            {
                errors.Add(metricName, 0);
            }
            return errors;
        }
    }
}
