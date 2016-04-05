using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;
using Cleaner.Parser;
using Cleaner.Utils;

namespace Cleaner
{
    public class Cca : CcaBase
    {
        public ICcaParser Parser { get; }

        public Cca(string path) : base(path)
        {
            Parser = new CcaParser(Files);
        }

        public void Start()
        {
            CcaProject project = Parser.Parse();
        }
    }
}
