using SupaDupaConsole.Commands;
using System;

namespace SupaDupaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            new OPENINGGODA().opening();
            MyConsole console = new MyConsole();
           console.EnterPoint();
        }
    }
}
