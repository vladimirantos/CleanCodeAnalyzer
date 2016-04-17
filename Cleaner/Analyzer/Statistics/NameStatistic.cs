using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Analyzer.Statistics
{
    class NameStatistic : BaseStatistic
    {
        public int ClassNames { get; }
        public int MethodNames { get; }
        public int VariablesNames { get; }

        public NameStatistic(int classNames, int methodNames, int variablesNames)
        {
            ClassNames = classNames;
            MethodNames = methodNames;
            VariablesNames = variablesNames;
        }

        public NameStatistic()
        {
            //todo: odstranit
        }
    }
}
