using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex z = new Complex(0, 1);
            Complex z1;
            z1 = z - (z * z * z - 1) / (3 * z * z);
            Console.WriteLine($"z1 = {z1}");
        }

    }
}
