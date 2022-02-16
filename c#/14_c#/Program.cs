using System;
using System.Linq;
using System.Collections.Generic;

namespace linq_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[5];

             Console.WriteLine("Ex1.Enter 5 numbers");

             for (var i = 0; i < 5; i++)
             {
                 mas[i] = int.Parse(Console.ReadLine());
             }


             var answer = String.Join(" ", mas.Where(n => n > 0));
             Console.WriteLine(answer);

            Console.WriteLine("Ex2.Enter 5 numbers");
             for (var i = 0; i < 5; i++)
             {
                 mas[i] = int.Parse(Console.ReadLine());
             }

            answer = String.Join(" ", mas.Where(i => i > 9 && i < 100).OrderBy(i => i));
             Console.WriteLine(answer);

            Console.WriteLine("Ex3.");
            GasStation first = new GasStation("92", 400, "A.corp", "Avenu1");
            GasStation second = new GasStation("92", 700, "B.corp", "Avenu1");
            GasStation third = new GasStation("98", 800, "C.corp", "Avenu2");
            GasStation fourth = new GasStation("98", 600, "A.corp", "Avenu2");
            GasStation fifth= new GasStation("95", 760, "B.corp", "Avenu3");
            GasStation sixth = new GasStation("95", 660, "C.corp", "Avenu3");

            var list = new List<GasStation>();
            list.Add(first);
            list.Add(second);
            list.Add(third);
            list.Add(fourth);
            list.Add(fifth);
            list.Add(sixth);

            var sorted = list.OrderBy(x => x.Mark).ThenBy(y=>y.Price);
            var Mark = sorted.First().Mark;
            foreach(var element in sorted)
            {
                if (element.Mark != Mark)
                {
                    Mark = element.Mark;
                    Console.WriteLine();
                }
                Console.Write(element.ToString()+" ");
                
            }
            

        }
    }
}
