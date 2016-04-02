using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;

namespace Cleaner.Analyzer
{
    public interface ICcaAnalyzer
    {
        CcaProject Project { get; }
        void Analyze();
    }

    public interface IAnalyzer<T>
    {
        T Analyze();
    }

    class CcaAnalyzer : ICcaAnalyzer
    {
        public CcaProject Project { get; private set; }

        public CcaAnalyzer(CcaProject project)
        {
            Project = project;
        }

        public void Analyze()
        {
            
        }
    }
}
