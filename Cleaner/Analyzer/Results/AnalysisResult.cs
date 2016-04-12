using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Analyzer.Results
{
    class AnalysisResult : BaseResult
    {
        public CodeLengthResult CodeLengthResult { get; }
        public NameResult NameResult { get; }

        public AnalysisResult(CodeLengthResult codeLengthResult, NameResult nameResult)
        {
            CodeLengthResult = codeLengthResult;
            NameResult = nameResult;
        }
    }
}
