using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Ex1();
            Ex2();
        }

        static void Ex1()
        {
            Random rnd = new Random();
            Student student = new Student("Drakon", "Zashel", "V", "Bar", 102, 10, 11, 12);

            //Console.WriteLine("Enter the marks of programming:");
            for (int i = 0; i < 10; i++)
            {
                student[0, i] = rnd.Next(1,10);
            }

            //Console.WriteLine("Enter the marks of administration:");
            for (int i = 0; i < 11; i++)
            {
                student[1, i] = rnd.Next(1, 10);
            }

            //Console.WriteLine("Enter the marks of design:");
            for (int i = 0; i < 12; i++)
            {
                student[2, i] = rnd.Next(1, 10);
            }

            Console.WriteLine(student.ToString());

        }

        static void Ex2()
        {
            Console.WriteLine("Starting matrix");
            Random rnd = new Random();
            int[,] matrix = new int[3, 4];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(1, 10);
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("After Matrix");

            int[,] trans = Mathematical.Transpose(matrix);
            for (int i = 0; i < trans.GetLength(0); i++)
            {
                for (int j = 0; j < trans.GetLength(1); j++)
                {
                    Console.Write(trans[i, j] + " ");
                }
                Console.WriteLine();
            }

            double a = 20, b = 12;

            Console.WriteLine($"Expontional function {Mathematical.Expon(a)}");
            Console.WriteLine($"Arcsin {Mathematical.Arcsin(b)}");
            Console.WriteLine($"distance 3d {Mathematical.DistanceBetweenPoint(10, 30, 10, 4, 7, 9)}");
        }
    }
   
}