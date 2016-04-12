using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Analyzer.Results
{
    class NameResult : BaseResult
    {
        public int ClassNames { get; }
        public int MethodNames { get; }
        public int VariablesNames { get; }

        public NameResult(int classNames, int methodNames, int variablesNames)
        {
            ClassNames = classNames;
            MethodNames = methodNames;
            VariablesNames = variablesNames;
        }
    }
}
