using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    static class Mathematical
    {
        public static double Expon(double d)
        {
            return Math.Exp(d);
        }
        public static double Arcsin(double gradus)
        {
            return Math.Asin(gradus / 57.29);
        }
        public static double DistanceBetweenPoint(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));
        }
        public static int [,] Transpose(int [,] matrix)
        {
            int [,] tmp = new int [matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    tmp[j, i] = matrix[i, j];
            }
            return tmp;
        }
    }
}