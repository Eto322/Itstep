using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_c_sharp
{
    struct Coefficient
    {
        public int A, B;
    }
    static class LinearEquation
    {
        public static void Parse(string data, ref Coefficient coefficient)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new FormatException("String is empty");
            }

            string[] number = data.Split(", ".ToCharArray());
            if (number.Length > 2)
            {
                throw new FormatException("Too many arguments.");
            }
            else if (number.Length < 2)
            {
                throw new FormatException("Too few arguments.");
            }
            else
            {
                bool rez = int.TryParse(number[0], out coefficient.A);
                if (!rez)
                    throw new FormatException("Can't convert first number to int32.");

                rez = int.TryParse(number[1], out coefficient.B);
                if (!rez)
                    throw new FormatException("Can't convert second number to int32.");
            }
        }

       
        public static double[] TheSolutionOfLinearEquation(string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                throw new FormatException("String is empty");
            }
            string[] tmp = param.Split(", ".ToCharArray());
            if (tmp.Length > 6)
            {
                throw new FormatException("Too many arguments.");
            }
            else if (tmp.Length < 6)
            {
                throw new FormatException("Too few arguments.");
            }

           

            double[] first_number = new double[3], second_number = new double[3];

            for (int i = 0, j = 0; i < tmp.Length; i++)
            {
                if (i > 2 && i < 6)
                {
                    if (!double.TryParse(tmp[i], out second_number[j]))
                    {
                        throw new FormatException($"Can't convert {j+1} number(second number) to int32.");
                    }
                   
                    j++;
                }
                else
                {
                   
                    if (!double.TryParse(tmp[i], out first_number[i]))
                    {
                        throw new FormatException($"Can't convert {i+1} number(first number) to int32.");
                    }
                }
            }

            double det = first_number[0] * second_number[1] - first_number[1] * second_number[0];
            if (det == 0)
            {
                throw new ArgumentOutOfRangeException("The solution does not exist.");
            }
            else
            {
                double[] rez = new double[2];

                rez[0] = (first_number[2] * second_number[1] - first_number[1] * second_number[2]) / det;
                rez[1] = (first_number[0] * second_number[2] - first_number[2] * second_number[0]) / det;

                return rez;
            }
        }
    }
}

