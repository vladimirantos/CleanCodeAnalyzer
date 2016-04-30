using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer;
using Cleaner.Analyzer.Statistics;
using Cleaner.Calibration;
using Cleaner.Comparator;
using Cleaner.Entity;
using Cleaner.Parser;
using Cleaner.Utils;

namespace Cleaner
{
    public class CcaFactory
    {
        public CcaProject Project { get; private set; }
        public List<ClassStatistics> Statistics { get; private set; }
        public List<Result> Result { get; private set; }

        public void Calibrate(string path) => Parse(path).Analyze().Calibration();

        public void Compare(string path) => Parse(path).Analyze().Comparator();

        public Dictionary<string, int> GetCalibrationData() => new ConfigurationReader(Config.CalibrationDataPath).ConfigData;

        private CcaFactory Parse(string path)
        {
            ICcaParser parser = new CcaParser(GetFiles(path));
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

        private List<FileInfo> GetFiles(string path) => FileUtils.GetAllFiles(path, Config.FilePattern, Config.ForbiddenDirs);
    }
}
