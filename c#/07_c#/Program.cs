using System;

namespace _8_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f = new Fraction(3, 4);
            int a = 10;
            Fraction f1 = f * a;
            Fraction f2 = a * f;
            double d = 1.5;
            Fraction f3 = f + d;
            bool is_equal = f1 == f2;
            bool is_less = f1 < f3;
            bool is_more = f1 > f3;

            if (f1)
                Console.WriteLine("true ");
            else
                Console.WriteLine("false");
        }
    }
}
