using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace BasicServerHTTPlistener
{
    class MyMethods
    {
        public string MyMethod(String param1_value, String param2_value)
        {
            return "<HTML><BODY> Hello " + param1_value + " et " + param2_value + "</BODY></HTML>";
        }

        public string MyExeMethod(string param1, string param2)
        {
            ProcessStartInfo start = new ProcessStartInfo
            {
                FileName = @"C:\Users\boein\Documents\MyExeMethod.exe",
                Arguments = param1 + " " + param2,
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}