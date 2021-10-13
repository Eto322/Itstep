using System;

namespace _5_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            new EX2.Counter().Start();

            Console.WriteLine("Press enter to continue");
            Console.ReadKey();

            new EX1.Menu().Start();

        }
    }
}
