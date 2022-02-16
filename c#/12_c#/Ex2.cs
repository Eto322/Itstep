using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate_
{
    class Ex2
    {
        

        static void ConsolePrint(int i)//Action
        {
            Console.WriteLine(i);
        }

        static void ConsolePrintX2(int i)//Action
        {
            Console.WriteLine(i + i);
        }

       
        bool isPositive(int value)//predicate
        {
            return value > 0;
        }

        int Sum(int x,int y)
        {
            return x + y;
        }
        public void Work()
        {
            Console.WriteLine("Action work");

            Action<int> print = ConsolePrint;
            print(1);
            print = ConsolePrintX2;
            print(1);

            Console.WriteLine("Predicate work(1 is positive?)");
            var pred = new Predicate<int>(isPositive);
            Console.WriteLine(pred(1));

            Console.WriteLine("Func work(sum 1+1)");
            Func<int, int,int> add = Sum;
          
            Console.WriteLine(add(1,1));



        }

    }
}


