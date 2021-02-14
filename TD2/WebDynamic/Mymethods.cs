using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DynamiqueWebServer
{
    public class Mymethods
    {
        public string param1, param2;
        public HttpListenerResponse response;

        public Mymethods(string p1, string p2, HttpListenerResponse resp)
        {
            param1 = p1; param2 = p2;
            response = resp;
        }

        

        public string dynamcPrint()
        {
            string toRet = "";
            toRet += "<html><body>Hello ";
            
            toRet += param1 +" et ";
            
            toRet += param2 + "\n";
            
            return toRet + "</body></html>";
        }

        public void executionHTML()
        {
            Console.WriteLine("==== we're here ====");
            //
            // Set up the process with the ProcessStartInfo class.
            // https://www.dotnetperls.com/process
            //
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Users\Anas1\Desktop\SI4\S2\Web-Service\TD2\eiin839\TD2\ExecTest\bin\Debug\ExecTest.exe"; // Specify exe name.
            start.Arguments = this.dynamcPrint(); // Specify arguments.
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            Console.WriteLine("start.Arguments = " + start.Arguments);
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
                    Console.WriteLine("!!!!!!!!!!!!!!! result = "+ result);
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(result);
                    // Get a response stream and write the response to it.
                    response.ContentLength64 = buffer.Length;
                    System.IO.Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    // You must close the output stream.
                    output.Close();
                }
            }
        }
    
    }
}
