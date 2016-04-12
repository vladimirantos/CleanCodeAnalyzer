using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.Results;
using Cleaner.Entity;

namespace Cleaner.Analyzer
{
    interface IAnalyzerHelper<T>
    {
        BaseResult Analyze(T analyzizedObject);
    }

    class AnalyzerProcess
    {
        private readonly CcaProject _project;
        private ClassAnalyzer _classAnalyzer;

        public AnalyzerProcess(CcaProject project)
        {
            _project = project;
        }

        public void Analyze()
        {
            _project.Files.ForEach(file =>
            {
                file.Classes.ForEach(ccaClass =>
                {
                    _classAnalyzer = new ClassAnalyzer(ccaClass);
                });
            });
        }


    }
}
