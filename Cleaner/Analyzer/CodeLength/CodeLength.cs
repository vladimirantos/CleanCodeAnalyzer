namespace Cleaner.Analyzer.CodeLength
{
    public abstract class CodeLength : Analyzer
    {
        protected string SourceCode { get; private set; }

        protected CodeLength(string sourceCode)
        {
            SourceCode = sourceCode;
        }
    }

    public class FileCodeLength : CodeLength
    {
        public FileCodeLength(string sourceCode) : base(sourceCode)
        {
        }


        public override void Analyze()
        {
           
        }
    }
}
