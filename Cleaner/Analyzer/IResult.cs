using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;

namespace Cleaner.Analyzer
{
    public interface IResult
    {
        CcaFile File { get; }
        CcaClass Class { get; }
        string Description { get; }
        List<IResult> ChildrenResults { get; } 
    }
}
