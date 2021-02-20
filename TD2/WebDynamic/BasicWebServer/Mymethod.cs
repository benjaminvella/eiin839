using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace BasicWebServer
{
    
    public class Mymethod
    {
        public string annee, pays, departement, ville;

        public Mymethod(string param1,string param2,string param3,string param4)
        {
            annee = param1;
            pays = param2;
            departement = param3;
            ville = param4;

        }

        public string displayHtml()
        {
            return "<HTML><BODY> L'examen du Baccalaureat 2 c'est déroulé dans le " + departement + " en " + pays +
                " plus précisement dans la ville de " + ville + " dans l' année " + annee + "</BODY></HTML>";

        }

        public void externalCall()
        {
            //
            // Set up the process with the ProcessStartInfo class.
            // https://www.dotnetperls.com/process
            //
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Users\R-mann\Documents\GitHub\eiin839\TD2\WebDynamic\Methode\bin\Debug\netcoreapp3.1\Methode.exe";
            start.Arguments = departement+" "+pays+" "+ville+" "+ annee ; // Specify arguments.
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
}
