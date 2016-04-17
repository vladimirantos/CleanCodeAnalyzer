using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Analyzer.Statistics
{
    class ClassStatistics
    {
        public int CountVariables { get; set; }
        public int CountProperties { get; set; }
        public int CountMethods { get; set; }
        public int CountSimilarityMethods { get; set; }
        public CodeLengthStatistics CodeLength { get; set; }
        public bool IsCorrectName { get; set; }
        public MethodStatistic MethodStatistic { get; set; }
        public int SimilarityMethods { get; set; }
    }
}
