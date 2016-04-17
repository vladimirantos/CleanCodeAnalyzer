using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Analyzer.Statistics
{
    public class MethodStatistic : BaseStatistic
    {
        public int CountArguments { get; set; }
        public int CyclomaticComplexity { get; set; }
    }
}
