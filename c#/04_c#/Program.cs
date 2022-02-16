using System;

namespace _4_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ex1();
            Ex2();
        }

        static void Ex1()
        {
            

            Coefficient coef = new Coefficient();
            Console.Write("Enter string with parameters for Linear Equation (A,B/A B) -> ");
            string param = Console.ReadLine();
            try
            {
                LinearEquation.Parse(param, ref coef);
                Console.WriteLine($"{coef.A}x + {coef.B}y = 0");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Ex2()
        {
            Console.Write("Enter string with parameters for Linear Equation (A1,B1,C1,A2,B2,C2/A1 B1 C1 A2 B2 C2) -> ");
            string param = Console.ReadLine();
            try
            {
                double[] rez = LinearEquation.TheSolutionOfLinearEquation(param);
                Console.WriteLine($"X -> {Math.Round(rez[0], 3)}\nY -> {Math.Round(rez[1], 3)}");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
