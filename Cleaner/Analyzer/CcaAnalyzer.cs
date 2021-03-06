﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.Statistics;
using Cleaner.Entity;

namespace Cleaner.Analyzer
{
    /// <summary>
    /// Veřejné rozhraní analyzátoru. 
    /// </summary>
    public interface IAnalyzer
    {
        List<ClassStatistics> ClassStatistics { get; }
        void Analyze();
    }

    /// <summary>
    /// Provádí výpočet metrik pro daný projekt.
    /// </summary>
    internal class CcaAnalyzer : IAnalyzer
    {
        private readonly CcaProject _project;
        private ClassAnalyzer _classAnalyzer;
        public List<ClassStatistics> ClassStatistics { get; private set; } = new List<ClassStatistics>();
        public CcaAnalyzer(CcaProject project)
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
                    ClassStatistics.Add(_classAnalyzer.Analyze());
                });
            });
        }


    }
}
