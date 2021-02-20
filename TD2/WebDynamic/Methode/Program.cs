using System;


namespace Methode
{

   
    class Program
    {
        static void Main(string[] args)
        {
        
                if (args.Length > 1)
                    Console.WriteLine("<HTML><BODY> L'examen du Baccalaureat 2 c'est déroulé dans le " + args[0] + " en " + args[1] +
                " plus précisement dans la ville de " + args[2] + " dans l' année " + args[3] + "</BODY></HTML>");
                else
                    Console.WriteLine("ExeTest <string parameter>");
           
        }
    }
}
