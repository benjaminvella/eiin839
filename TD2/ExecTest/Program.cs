using System;

namespace ExeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
                Console.WriteLine(args[0]);
            else
                Console.WriteLine("ExeTest <string parameter>");
        }

        public string Method2(string firstParam, string secondParam)
        {
            return "<html><body> Hello " + firstParam + " et " + secondParam + "</body></html>";
        }
    }


}
