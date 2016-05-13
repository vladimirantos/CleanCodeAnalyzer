using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Utils.Extensions
{
    public static class ObjectExtensions
    {
        public static Dictionary<string, int> ToDictionary(this object source)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
            {
                object value  = property.GetValue(source);
                if(value is int)
                    dictionary.Add(property.Name, (int)value);
            }
            return dictionary;
        }
    }
}
