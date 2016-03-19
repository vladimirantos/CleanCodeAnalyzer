using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Class1
    {
        private int _x;
    }

    public abstract class Class2 : Class1
    {
        public bool Has()
        {
            return true;
        }
        
    }
}
