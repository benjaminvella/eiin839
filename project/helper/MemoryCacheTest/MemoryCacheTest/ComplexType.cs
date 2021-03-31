using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryCacheTest
{
    class ComplexType
    {
        int _counter;

        public ComplexType(int val_init)
        {
            counter = val_init;
        }
        public int counter
            {
            get 
            { 
                return _counter;
            }
            set
            {
                _counter = value;
            }
        }

        public void incr()
        {
            counter++;
        }
        public string display()
        {
            return Convert.ToString(counter);
        }
    }
}
