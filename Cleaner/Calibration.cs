using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.Statistics;
using Cleaner.Entity;
using Cleaner.Utils;

namespace Cleaner
{
    interface ICalibration
    {
        void Calibrate();
        void Save(string path);
    }

    class Calibration : ICalibration
    {
        private readonly List<ClassStatistics> _statistics;
        private readonly ConfigurationWriter _calibrationWriter;

        public Calibration(List<ClassStatistics> statistics, string calibrationFilePath)
        {
            _statistics = statistics;
            _calibrationWriter = ConfigurationFile.Writer(calibrationFilePath);
        }

        public void Calibrate()
        {
            _statistics.ForEach(classStatistic =>
            {
                
            });   
        }

        public void Save(string path)
        {
            throw new NotImplementedException();
        }

        private void CountAvg(ref int value, ref int count)
        {
            
        }
    }
}
