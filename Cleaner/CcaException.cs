using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner
{
    class CcaException : ApplicationException
    {
        public CcaException()
        {
        }

        public CcaException(string message) : base(message)
        {
        }

        public CcaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
