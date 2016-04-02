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
    public class Cca
    {
        protected ICcaParser Parser { get; set; }
        protected ICcaAnalyzer Analyzer { get; set; }
        
        private Cca(List<FileInfo> files)
        {
            Parser = new CcaParser(files);
        }

        public static Cca Create(string path, string filePattern, StringCollection forbiddenDir)
        {
            return new Cca(FileUtils.GetAllFiles(path, filePattern, forbiddenDir));
        }

        public void Start()
        {
            CcaProject project = Parser.Parse();
        }
    }
}
