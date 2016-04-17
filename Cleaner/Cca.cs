using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer;
using Cleaner.Entity;
using Cleaner.Parser;
using Cleaner.Utils;

namespace Cleaner
{
    public class Cca : CcaBase
    {
        public override ICcaParser Parser => new CcaParser(Files);
        public Cca(string path) : base(path) { }
        public void Start()
        {
            CcaProject project = Parser.Parse();
            AnalyzerProcess ap = new AnalyzerProcess(project);
            ap.Analyze();
        }
    }
}
