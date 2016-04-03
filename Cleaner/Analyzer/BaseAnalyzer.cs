using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;

namespace Cleaner.Analyzer
{
    interface ICcaAnalyzer
    {
        void Analyze();
    }

    interface IAnalyze
    {
         
    }

    abstract class BaseAnalyzer : ICcaAnalyzer
    {
        protected CcaProject Project { get; }

        protected BaseAnalyzer(CcaProject project)
        {
            Project = project;
        }

        public abstract void Analyze();
    }
}
