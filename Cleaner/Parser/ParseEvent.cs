using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;

namespace Cleaner.Parser
{
    public class ParseEvent : EventArgs
    {
        public string File { get; }
        public CcaClass Class { get; }

        public ParseEvent(string file, CcaClass @class)
        {
            File = file;
            Class = @class;
        }
    }
}
