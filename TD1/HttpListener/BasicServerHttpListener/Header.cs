using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Header
    {
        public static void ShowHeader(HttpListenerRequest request)
        {
            foreach (var header in request.Headers)
            {
                Console.WriteLine(header);
            }
        }
    }
}
