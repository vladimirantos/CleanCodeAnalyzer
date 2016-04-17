using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.Helpers;
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
            Console.WriteLine(_class.Header.Name);
            ClassStatistics statistics = new ClassStatistics()
            {
                CountVariables = _class.Variables.Count,
                CountProperties = _class.Properties.Count,
                CountMethods = _class.Methods.Count,
                CodeLength = (CodeLengthStatistics)CodeLength.Analyze(_class.Content),
                SimilarityMethods = (int)SimilarityMethods.Analyze(_class.Methods)
            };
            Console.WriteLine(statistics.SimilarityMethods);
            return statistics;
        }
    }
}
