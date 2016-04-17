using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Analyzer.Statistics
{
    public class ClassStatistics : BaseStatistic
    {
        public int CountVariables { get; set; }
        public int CountProperties { get; set; }
        public int CountMethods { get; set; }
        public int CountSimilarityMethods { get; set; }
        public List<MethodStatistic> MethodStatistic { get; set; }
        public int SimilarityMethods { get; set; }
    }
}
