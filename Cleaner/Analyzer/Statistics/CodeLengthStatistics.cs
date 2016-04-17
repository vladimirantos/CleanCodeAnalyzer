using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Analyzer.Statistics
{
    class CodeLengthStatistics : BaseStatistic
    {
        public int CodeLength { get; }
        public int CommentsCount { get; }
        public int WhitespaceCount { get; }

        public CodeLengthStatistics(int codeLength, int commentsCount, int whitespaceCount)
        {
            CodeLength = codeLength;
            CommentsCount = commentsCount;
            WhitespaceCount = whitespaceCount;
        }
    }
}
