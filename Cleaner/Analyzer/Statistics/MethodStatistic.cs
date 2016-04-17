using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Analyzer.Statistics
{
    class MethodStatistic
    {
        public bool IsCorrectName { get; set; }
        public bool CountArguments { get; set; }
        public CodeLengthStatistics CodeLength { get; set; }
        public int CyclomaticComplexity { get; set; }
    }
}
