using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;

namespace Cleaner.Analyzer
{
    interface IResult
    {
        Location Location { get; }
        string Description { get; }
        List<IResult> InnerResults { get; }
    }

    class Location
    {
        public string File { get; }
        public CcaClass Class { get; }
        public CcaMethod Method { get; } = null;
        public int? Line { get; } = null;

        public Location(string file, CcaClass ccaClass)
        {
            File = file;
            Class = ccaClass;
        }
    }
}
