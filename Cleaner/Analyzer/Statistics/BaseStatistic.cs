using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Analyzer.Statistics
{
    public class BaseStatistic
    {
        public int NameCount { get; set; }
        public bool IsCorrectName { get; set; }
        public CodeLengthStatistics CodeLength { get; set; }
    }
}
