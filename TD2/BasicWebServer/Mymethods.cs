using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer
{
    class Mymethods
    {
        public string Method1(string firstParam, string secondParam)
        {
            return "<html><body> Hello " + firstParam + " et " + secondParam + "</body></html>";
        }
    }
}
