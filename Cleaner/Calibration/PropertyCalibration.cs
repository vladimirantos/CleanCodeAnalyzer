using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.Statistics;
using Cleaner.Utils;

namespace Cleaner.Calibration
{
   internal class PropertyCalibration : BaseCalibration<PropertyStatistic>
    {
        public PropertyCalibration(ConfigurationWriter writer) : base(writer)
        {
        }

        public override void Calibrate(IEnumerable<PropertyStatistic> collection)
        {
            base.Calibrate(collection);
            AddCalibrationValue("PROP_NAME_LENGTH", p => p.NameLength);
            AddCalibrationValue("PROP_CORRECT_NAMES", p => p.IsCorrectName ? 1 : 0, RoundTwoDecimal);
        }
    }
}
