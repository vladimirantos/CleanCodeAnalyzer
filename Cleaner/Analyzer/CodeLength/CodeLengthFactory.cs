using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Analyzer.CodeLength
{
    class CodeLengthFactory
    {
        public FileCodeLength CreateFileCodeLength(string source)
        {
            return new FileCodeLength(source);
        }
    }
}
