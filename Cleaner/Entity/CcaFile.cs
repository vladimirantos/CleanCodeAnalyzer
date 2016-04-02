using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Entity
{
    public class CcaFile
    {
        public List<CcaClass> Classes { get; set; }
        public string SourceCode { get; set; }

        public CcaFile(List<CcaClass> classes, string sourceCode)
        {
            Classes = classes;
            SourceCode = sourceCode;
        }
    }
}
