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
    /// <summary>
    /// Vstupní třída do knihovny Cleaner.
    /// </summary>
    public class CcaFactory
    {
        public CcaProject Project { get; private set; }
        public List<ClassStatistics> Statistics { get; private set; }
        public List<CcaResult> Result { get; private set; }

        /// <summary>
        /// Provádí analýzu vzorového kódu ze zadaného adresáře a vypočítá hodnoty kalibrace.
        /// </summary>
        /// <param name="path">Cesta ke zdrojovým souborům</param>
        public void Calibrate(string path) => Parse(path).Analyze().Calibration();

        /// <summary>
        /// Analyzuje zadaný kód a porovná jej s výsledky kalibrace.
        /// </summary>
        /// <param name="path">Cesta ke zdrojovým souborům</param>
        public void Analyze(string path) => Parse(path).Analyze().Comparator();

        /// <summary>
        /// Vrací seznam kalibračních dat. Klíčem je název metriky a hodnotou je průměrný počet.
        /// </summary>
        public Dictionary<string, float> GetCalibrationData() => new ConfigurationReader(Config.CalibrationDataPath).ConfigData;

        /// <summary>
        /// Kontroluje, jestli jsou k dispozici kalibrační data.
        /// </summary>
        /// <returns></returns>
        public bool CalibrationDataExists() => File.Exists(Config.CalibrationDataPath);

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
