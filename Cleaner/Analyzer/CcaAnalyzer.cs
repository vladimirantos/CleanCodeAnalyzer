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
    class CcaAnalyzer : ICcaAnalyzer
    {
        private readonly CcaProject _project;
        
        public CcaAnalyzer(CcaProject project)
        {
            _project = project;
        }

        public void Analyze()
        {
            
        }
    }
}