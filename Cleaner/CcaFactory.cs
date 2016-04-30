using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer;
using Cleaner.Analyzer.Statistics;
using Cleaner.Calibration;
using Cleaner.Comparator;
using Cleaner.Entity;
using Cleaner.Parser;

namespace Cleaner
{
    public class CcaFactory : CcaBase
    {
        public CcaProject Project { get; private set; }
        public List<ClassStatistics> Statistics { get; private set; }
        public List<Result> Result { get; private set; }
        public CcaFactory(string path) : base(path) { }

        public void Calibrate() => Parse().Analyze().Calibration();

        public void Compare() => Parse().Analyze().Comparator();

        private CcaFactory Parse()
        {
            ICcaParser parser = new CcaParser(Files);
            Project = parser.Parse();
            return this;
        }

        private CcaFactory Analyze()
        {
            IAnalyzer analyzer = new CcaAnalyzer(Project);
            analyzer.Analyze();
            Statistics = analyzer.ClassStatistics;
            return this;
        }

        private CcaFactory Calibration()
        {
            ICalibration<ClassStatistics> calibration = new CcaCalibration();
            calibration.Calibrate(Statistics);
            calibration.Save(Config.CalibrationDataPath);
            return this;
        }

        private CcaFactory Comparator()
        {
            IComparator comparator = new CcaComparator(Config.CalibrationDataPath);
            comparator.Compare(Statistics);
            Result = comparator.Results;
            return this;
        }
    }
}
