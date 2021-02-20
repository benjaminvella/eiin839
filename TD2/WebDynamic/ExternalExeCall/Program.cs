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
        start.FileName = @"C:\Users\R-mann\Documents\GitHub\eiin839\TD2\ExecTest\bin\Debug\ExecTest.exe"; 
        start.Arguments = "Argument1"; // Specify arguments.
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