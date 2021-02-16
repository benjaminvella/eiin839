using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BasicServerHTTPlistener
{
    class Header
    {
        public void GetHeader(HttpListenerRequest request)
        {
            Console.WriteLine("Header fields : " + request.Headers[HttpRequestHeader.Accept.ToString()] + request.Headers[HttpRequestHeader.Connection.ToString()]);
        }
    }
}