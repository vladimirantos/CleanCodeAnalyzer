using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Analyzer.Results
{
    class CodeLengthResult : BaseResult
    {
        public int CodeLength { get; }
        public int CommentsCount { get; }
        public int WhitespaceCount { get; }

        public CodeLengthResult(int codeLength, int commentsCount, int whitespaceCount)
        {
            CodeLength = codeLength;
            CommentsCount = commentsCount;
            WhitespaceCount = whitespaceCount;
        }
    }
}
