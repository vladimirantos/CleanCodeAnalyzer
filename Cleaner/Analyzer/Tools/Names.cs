using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.Statistics;
using Cleaner.Entity;

namespace Cleaner.Analyzer.Tools
{
    class Names : IAnalyzerHelper<BaseStatistic>
    {
        public int Length(string name) => name.Length;

        public BaseStatistic Analyze(IElement analyzizedObject)
        {
//            return new NameStatistic();
            return null;
        }

        public BaseStatistic Analyze()
        {
            throw new NotImplementedException();
        }
    }
}
