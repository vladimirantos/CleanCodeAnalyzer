using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CleanCodeAnalyzer
{
    class Logger
    {
        readonly TextBlock _textBlock;
   
        public Logger(TextBlock textBlock)
        {
            _textBlock = textBlock;
        }

        public void Add(string message)
        {
            _textBlock.Text += message + "\n";
        }
    }
}
