using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.Results;
using Cleaner.Entity;

namespace Cleaner.Analyzer.Helpers
{
    class Names : IAnalyzerHelper<IElement>
    {
        public int Length(string name) => name.Length;

        public BaseResult Analyze(IElement analyzizedObject)
        {
//            return new NameResult();
            return null;
        }
    }
}
