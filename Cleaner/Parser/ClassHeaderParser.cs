using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;

namespace Cleaner.Parser
{
    class ClassHeaderParser : BaseParser
    {
        public ClassHeader Result { get; private set; }
        public ClassHeaderParser(string text) : base(text)
        {
        }

        public override void Parse()
        {
            
        }
    }
}
