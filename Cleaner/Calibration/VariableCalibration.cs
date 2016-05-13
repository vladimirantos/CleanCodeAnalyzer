using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.Statistics;
using Cleaner.Utils;

namespace Cleaner.Calibration
{
    internal class VariableCalibration : BaseCalibration<VariableStatistics>
    {
        public VariableCalibration(ConfigurationWriter writer) : base(writer)
        {
        }

        public override void Calibrate(IEnumerable<VariableStatistics> collection)
        {
            base.Calibrate(collection);
            AddCalibrationValue("VAR_NAME_LENGTH", v => v.NameLength);
            AddCalibrationValue("VAR_CORRECT_NAMES", v => v.IsCorrectName ? 1 : 0, RoundTwoDecimal);
        }
    }
}
