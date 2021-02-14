using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        //
        // Set up the process with the ProcessStartInfo class.
        // https://www.dotnetperls.com/process
        //
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = @"C:\Users\dyiem\OneDrive\Bureau\Cours SI4\Semestre 8\Service oriented computing\TD\Mon premier serveur web dans mon serveur TCP-IP Socket\Forked\eiin839\TD2\WebDynamic\ExecTest\bin\Debug\ExecTest.exe"; // Specify exe name.
        start.Arguments = "http://localhost:8080/liste/users/1?name=robert&surname=richard&age=33"; // Specify arguments.
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
                Console.WriteLine(result);
                Console.ReadLine();
            }
        }
    }
}