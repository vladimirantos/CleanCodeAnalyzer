using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Parser
{
    public interface IParser<T>
    {
        T Parse();
    }
}
