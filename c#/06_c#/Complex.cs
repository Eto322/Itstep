using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Complex
    {
        public double _really { get; set; }
        public double _imaginary { get; set; }
        public Complex(double really, double imaginary)
        {
            _really = really;
            _imaginary = imaginary;
        }
        public static Complex operator +(Complex left, Complex right)
        {
            return new Complex(left._really + right._really, left._imaginary + right._imaginary);
        }
        public static Complex operator +(int left, Complex right)
        {
            return new Complex(left + right._really, right._imaginary);
        }
        public static Complex operator +(Complex left, int right)
        {
            return new Complex(left._really + right, left._imaginary);
        }
        public static Complex operator -(Complex left, Complex right)
        {
            return new Complex(left._really - right._really, left._imaginary - right._imaginary);
        }
        public static Complex operator -(Complex left, int right)
        {
            return new Complex(left._really - right, left._imaginary);
        }
        public static Complex operator -(int left, Complex right)
        {
            return new Complex(left - right._really, 0 - right._imaginary);
        }
        public static Complex operator *(Complex left, Complex right)
        {
            return new Complex(left._really * right._really - left._imaginary * right._imaginary, left._imaginary * right._really + left._really * right._imaginary);
        }
        public static Complex operator *(int left, Complex right)
        {
            return new Complex(left * right._really, left * right._imaginary);
        }
        public static Complex operator *(Complex left, int right)
        {
            return new Complex(left._really * right, left._imaginary * right);
        }
        public static Complex operator /(Complex left, Complex right)
        {
            double really = (left._really * right._really + left._imaginary * right._imaginary) / (Math.Pow(right._really, 2) + Math.Pow(right._imaginary, 2));
            double imaginary = (left._imaginary * right._really - left._really * right._imaginary) / (Math.Pow(right._really, 2) + Math.Pow(right._imaginary, 2));
            return new Complex(really, imaginary);
        }
        public static Complex operator /(int left, Complex right)
        {
            double really = (left * right._really) / (Math.Pow(right._really, 2) + Math.Pow(right._imaginary, 2));
            double imaginary = (0 - left * right._imaginary) / (Math.Pow(right._really, 2) + Math.Pow(right._imaginary, 2));
            return new Complex(really, imaginary);
        }
        public static Complex operator /(Complex left, int right)
        {
            double really = (left._really * right) / (Math.Pow(right, 2));
            double imaginary = (left._imaginary * right) / (Math.Pow(right, 2));
            return new Complex(really, imaginary);
        }
        public override string ToString()
        {
            if (_imaginary < 0)
            {
                return $"{Math.Round(_really, 2)} - {Math.Round(Math.Abs(_imaginary), 2)}i";
            }
              
            return $"{Math.Round(_really, 2)} + {Math.Round(_imaginary, 2)}i";
        }
    }
}