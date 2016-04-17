using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Analyzer.Statistics
{
    class AnalysisStatistic : BaseStatistic
    {
        public CodeLengthStatistics CodeLengthStatistics { get; }
        public NameStatistic NameStatistic { get; }

        public AnalysisStatistic(CodeLengthStatistics codeLengthStatistics, NameStatistic nameStatistic)
        {
            CodeLengthStatistics = codeLengthStatistics;
            NameStatistic = nameStatistic;
        }
    }
}
