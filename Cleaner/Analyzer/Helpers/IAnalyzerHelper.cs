using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.Statistics;

namespace Cleaner.Analyzer.Helpers
{
    interface IAnalyzerHelper<T>
    {
        T Analyze();
    }

}
