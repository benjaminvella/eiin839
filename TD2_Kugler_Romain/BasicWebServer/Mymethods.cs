using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer
{
    class Mymethods
    {

        //  http://localhost:8080/Method1?param1=coucou&param2=hihi
        public string Method1(string firstParam, string secondParam)
        {
            return "<html><body> Hello " + firstParam + " and " + secondParam + "</body></html>";
        }

        //  http://localhost:8080/Method2?param1=coucou&param2=hihi
        public string Method2(string firstParam, string secondParam)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            //start.FileName = @"C:\Users\romai\Desktop\Cours\Polytech\SI4\S8\SOC\soc\TD2\ExecTest\bin\Debug\ExecTest.exe"; // Specify exe name.
            start.FileName = @"..\..\..\..\Exec\bin\Debug\net6.0\Exec.exe"; // Specify exe name.
            start.Arguments = firstParam + " " + secondParam; // Specify arguments.
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            //
            // Start the process.
            //
            using (Process process = Process.Start(start))
            {
                //
                // Read in all the text from the process with the StreamReader.
                //
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    //Console.WriteLine(result);
                    Console.ReadLine();
                    return result;
                }
            }
        }
    }
}
