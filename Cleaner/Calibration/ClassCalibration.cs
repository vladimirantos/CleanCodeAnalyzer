using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.Statistics;
using Cleaner.Utils;

namespace Cleaner.Calibration
{
    class ClassCalibration : BaseCalibration<ClassStatistics>
    {
        public ClassCalibration(ConfigurationWriter writer) : base(writer) { }

        public override void Calibrate(IEnumerable<ClassStatistics> collection)
        {
            base.Calibrate(collection);
            AddCalibrationValue("CLASS_NAME_LENGTH", cls => cls.NameLength);
            AddCalibrationValue("CLASS_CORRECT_NAMES", cls => cls.IsCorrectName ? 1 : 0, RoundTwoDecimal);
            AddCalibrationValue("CLASS_CODE_LINES", cls => cls.CodeLength.Length);
            AddCalibrationValue("CLASS_COMMENTS_LINES", cls => cls.CodeLength.CommentsCount);
            AddCalibrationValue("CLASS_WHITESPACE_LINES", cls => cls.CodeLength.WhitespaceCount);
            AddCalibrationValue("COUNT_VARIABLES", cls => cls.CountVariables);
            AddCalibrationValue("COUNT_PROPERTIES", cls => cls.CountProperties);
            AddCalibrationValue("COUNT_METHODS", cls => cls.CountMethods);
            AddCalibrationValue("COUNT_SIMILARITY_METHODS", cls => cls.SimilarityMethods);
        }
    }
}
