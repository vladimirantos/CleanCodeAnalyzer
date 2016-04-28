using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer;
using Cleaner.Analyzer.Statistics;
using Cleaner.Entity;
using Cleaner.Parser;
using Cleaner.Utils;

namespace Cleaner
{
    public class Cca : CcaBase
    {
        public override ICcaParser Parser => new CcaParser(Files);
        public CcaProject Project { get; private set; }
        public List<ClassStatistics> Statistics { get; private set; }
        public Cca(string path) : base(path) { }

        public void Start()
        {
            Parse().Analyze();
        }

        private Cca Parse()
        {
            Project = Parser.Parse();
            return this;
        }

        private Cca Analyze()
        {
            CcaAnalyzer analyzer = new CcaAnalyzer(Project);
            analyzer.Analyze();
            Statistics = analyzer.ClassStatistics;
            return this;
        }
    }
}
