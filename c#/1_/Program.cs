using System;

namespace _123
{
    class Program
    {
        static void Main()
        {
            ex1();
            ex2();
            ex3();
            ex4();
        }

        static void ex1()
        {
            Console.WriteLine("Ex1 \n Enter symbols:");
            char inputSymbols=' ';
            int count = 0 ;

            while (inputSymbols !='.')
            {
                inputSymbols = Console.ReadKey().KeyChar;
                if (inputSymbols==' ')
                {
                    count++;
                }

            }
            Console.WriteLine("\nNumber of space "+count);
        }

        static void ex2()
        {
           
            char ch;
            int first_part = 0;
            int secon_part = 0;
            Console.WriteLine("EX2\n enter ticket");
            for (int i = 0; i < 6; i++)
            {

                ch = Console.ReadKey().KeyChar;
                if (i < 3)
                {
                    first_part += ch;
                }
                else
                {
                    secon_part += ch;
                }
            }
            if (first_part == secon_part)
            {
                Console.WriteLine("\nlucky");
            }
            else
            {
                Console.WriteLine("\nnot lucky");
            }

            

        }

       static void ex3()
        {
            Console.WriteLine("EX3\n enter string");
            string convert = Console.ReadLine();
            Console.WriteLine(convert.ToUpper());
        }

        static void ex4()
        {
            Console.WriteLine("EX4\n enter number");
            string convert = Console.ReadLine();
            string output = "";
            for (int i = convert.Length-1; i >=0; i--)
            {
                output += convert[i];
            }
            Console.WriteLine(output);
        }
    }
}
