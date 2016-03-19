using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.CodeLength;

namespace Cleaner.Analyzer
{
    class CcAnalyzer
    {
        public List<FileInfo> Files { get; private set; }

        public CcAnalyzer(List<FileInfo> files)
        {
            Files = files;
        }

        public CodeLengthFactory CodeLength()
        {
            return new CodeLengthFactory();
        }

        public void Analyze()
        {
            CodeLengthFactory codeLengthFactory = CodeLength();
            foreach (var fileInfo in Files)
            {
                string content = fileInfo.ToString();
                codeLengthFactory.CreateFileCodeLength(content);
            }
        }
    }
}
