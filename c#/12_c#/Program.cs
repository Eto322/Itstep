using System;

namespace delegate_

{
    class Program
    {
        static void Main()
        {
            Ex2 ex2 = new Ex2();
            Ex1 ex1 = new Ex1();
            ex1.Work();
            Console.WriteLine();
            ex2.Work();
        }
    }
}