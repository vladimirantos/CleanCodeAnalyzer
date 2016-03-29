using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public abstract class Parent
    {
        private string _parentX;
        private string _parentY;
        public virtual string Pokus { get; set; }

        public static int Calculate(int x, int y, int z)
        {
            return x + y + z;
        }
    }

    public abstract class Child : ICloneable
    {
        private string _childX;
        public string _childY;
        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
