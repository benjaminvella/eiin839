using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo3Server
{
    class Mymethods
    {
        public string Incr(string intParam)
        {
            int res;
            if (!int.TryParse(intParam, out res))
            {
                return "Error : bad int format";
            }
            res++;
            return res.ToString();
        }
    }
}
