using System;

namespace ExeTest
{
    class Program
    {

        static void Main(string[] args)
        {
            int n = args.Length;
            if (n >= 1)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("args["+i+"] = "+args[i]);
                }
            }
            else
                Console.WriteLine("ExeTest <string parameter>");
        }
    }
}
