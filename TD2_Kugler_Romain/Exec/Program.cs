using System;

namespace Method2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
                Console.WriteLine("<html><body> This is method2, but still : Hello " + args[0] + " and " + args[1] + "</body></html>");
            else
                Console.WriteLine("usage : Method2 stringParam1 stringParam2");
        }

    }
}
