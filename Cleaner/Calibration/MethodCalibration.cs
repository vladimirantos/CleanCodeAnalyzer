using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.Statistics;
using Cleaner.Utils;

namespace Cleaner.Calibration
{
    internal class MethodCalibration : BaseCalibration<MethodStatistic>
    {
        public MethodCalibration(ConfigurationWriter writer) : base(writer) { }

        public override void Calibrate(IEnumerable<MethodStatistic> collection)
        {
            base.Calibrate(collection);
            AddCalibrationValue("METHOD_NAME_LENGTH", m => m.NameLength);
            AddCalibrationValue("METHOD_CORRECT_NAMES", m => m.IsCorrectName ? 1 : 0, RoundTwoDecimal);
            AddCalibrationValue("METHOD_CODE_LINES", m => m.CodeLength.Length);
            AddCalibrationValue("METHOD_COMMENTS_LINES", m => m.CodeLength.CommentsCount);
            AddCalibrationValue("METHOD_WHITESPACE_LINES", m => m.CodeLength.WhitespaceCount);
            AddCalibrationValue("METHOD_COUNT_ARGS", m => m.CountArguments);
            AddCalibrationValue("CYCLOMATIC_COMPLX",m => m.CyclomaticComplexity);
        }
    }
}
