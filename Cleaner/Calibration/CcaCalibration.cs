using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.Statistics;
using Cleaner.Utils;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cleaner.Calibration
{
    /// <summary>
    /// Provádí výpočet kalibračních dat. Ukládá do souboru průměrné hodnoty metrik.
    /// </summary>
    internal class CcaCalibration : BaseCalibration<ClassStatistics>
    {
        public CcaCalibration() : base(new ConfigurationWriter()) { }

        public override void Calibrate(IEnumerable<ClassStatistics> collection)
        {
            base.Calibrate(collection);
            ClassCalibrate(Collection);
            MethodCalibrate(Collection.SelectMany(cls => cls.MethodStatistics));   
            PropertyCalibrate(Collection.SelectMany(cls => cls.PropertyStatistics));
            VariableCalibrate(Collection.SelectMany(cls => cls.VariableStatistics));
        }

        private void ClassCalibrate(IEnumerable<ClassStatistics>  statistics) 
            => new ClassCalibration(CalibrationWriter).Calibrate(statistics);

        private void MethodCalibrate(IEnumerable<MethodStatistic> statistic) 
            => new MethodCalibration(CalibrationWriter).Calibrate(statistic);

        private void PropertyCalibrate(IEnumerable<PropertyStatistic> statistics)
            => new PropertyCalibration(CalibrationWriter).Calibrate(statistics);

        private void VariableCalibrate(IEnumerable<VariableStatistics> statistics)
            => new VariableCalibration(CalibrationWriter).Calibrate(statistics);
    }
}
