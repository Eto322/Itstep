using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrlenght;

            Console.Write("Enter the size of massive -> ");
            arrlenght = Int32.Parse(Console.ReadLine());
            
            Shop arr = new Shop(arrlenght);

            string brand;
            double diagonal, weight;

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Enter product brand -> ");
                brand = Console.ReadLine();
                
                Console.Write("Enter the diagonal of the product screen -> ");
                diagonal = Double.Parse(Console.ReadLine());
                
                Console.Write("Enter the weight of the product -> ");
                weight = Double.Parse(Console.ReadLine());
                
                arr[i] = new Laptop(brand, diagonal, weight);
                
                Console.Clear();
            }

            //Shop arr = new Shop();

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine(arr[i]);
            }
        }
    }
}