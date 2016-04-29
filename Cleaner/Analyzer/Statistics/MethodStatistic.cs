using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;

namespace Cleaner.Analyzer.Statistics
{
    public class MethodStatistic : BaseStatistic
    {
        public CcaMethod Method { get; set; }
        public int CountArguments { get; set; }
        public int CyclomaticComplexity { get; set; }
    }
}
