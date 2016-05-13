using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Parser
{
    /// <summary>
    /// Pomocné vnitřní rozhraní pro části parseru.
    /// </summary>
    public interface IParser<T>
    {
        T Parse();
    }
}
