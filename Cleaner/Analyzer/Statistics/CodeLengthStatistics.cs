using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Analyzer.Statistics
{
    public class CodeLengthStatistics : BaseStatistic
    {
        public int Length { get; }
        public int CommentsCount { get; }
        public int WhitespaceCount { get; }

        public CodeLengthStatistics(int length, int commentsCount, int whitespaceCount)
        {
            Length = length;
            CommentsCount = commentsCount;
            WhitespaceCount = whitespaceCount;
        }
    }
}
