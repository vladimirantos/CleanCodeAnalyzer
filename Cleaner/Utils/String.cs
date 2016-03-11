using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Utils
{
    static class String
    {
        public static bool IsUpper(this string text)
        {
            return text.All(char.IsUpper);
        }
    }
}
