using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;

namespace Cleaner.Analyzer.Statistics
{
    public class ClassStatistics : BaseStatistic
    {
        public CcaClass CcaClass { get; set; }
        public int CountVariables { get; set; }
        public int CountProperties { get; set; }
        public int CountMethods { get; set; }
        public List<MethodStatistic> MethodStatistics { get; set; }
        public List<PropertyStatistic> PropertyStatistics { get; set; }
        public List<VariableStatistics> VariableStatistics { get; set; }
        public int SimilarityMethods { get; set; }
    }
}
