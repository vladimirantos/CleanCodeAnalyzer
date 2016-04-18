using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Analyzer.Tools
{
    class CyclomaticComplexity : IAnalyzerHelper<int>
    {
        private string _content;

        private CyclomaticComplexity(string content)
        {
            _content = content;
        }

        public static int Analyze(string content)
        {
            return new CyclomaticComplexity(content).Analyze();
        }

        public int Analyze()
        {
            string[] lines = _content.Split('\n');
            return 0;
        }
    }
}
