using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_c_sharp
{
    class Fraction
    {
        public  double Numerator { get; set; }
        public double Denumerator { get; set; }
        public Fraction(double Numerator, double Denumerator)
        {
            this.Numerator = Numerator;
            this.Denumerator = Denumerator;
        }

       
        public Fraction() : this(0, 1) { }
        public override string ToString()
        {
            return $"{Numerator}/{Denumerator}";
        }
        public static Fraction operator *(Fraction left, Fraction right)
        {
            return new Fraction(left.Numerator * right.Numerator, left.Denumerator * right.Denumerator);
        }
        public static Fraction operator *(Fraction left, double right)
        {
            return new Fraction(left.Numerator * right, left.Denumerator);
        }
        public static Fraction operator *(double left, Fraction right)
        {
            return new Fraction(left * right.Numerator, right.Denumerator);
        }

      
        public static double lcm(double a, double b)
        {
            double first, second;
            if (a > b)
            {
                first = a; second = b;
            }
            else
            {
                first = b; second = a;
            }

            for (int i = 1; i < second; i++)
            {
                double mult = first * i;
                if (mult % second == 0)
                {
                    return mult;
                }
            }
            return first * second;
        }
        public static Fraction operator +(Fraction left, Fraction right)
        {
            return new Fraction(left.Numerator * (lcm(left.Denumerator, right.Denumerator) / left.Denumerator) + right.Numerator * (lcm(left.Denumerator, right.Denumerator) / right.Denumerator), lcm(left.Denumerator, right.Denumerator));
        }
        public static Fraction operator +(Fraction left, double right)
        {
            return left + new Fraction(right, 1);
        }

       

        public static explicit operator double(Fraction obj)
        {
            return (double)obj.Numerator / obj.Denumerator;
        }
        public static Fraction operator ++(Fraction obj)
        {
            obj.Numerator += obj.Denumerator;
            return obj;
        }
        public static Fraction operator !(Fraction obj)
        {
            (obj.Numerator, obj.Denumerator) = (obj.Denumerator, obj.Numerator);
            return obj;
        }
        public static bool operator ==(Fraction left, Fraction right)
        {
            double clm = lcm(left.Denumerator, right.Denumerator);
            double a = left.Numerator * clm / left.Denumerator;
            double b = right.Numerator * clm / right.Denumerator;
            return a == b;
        }
        public static bool operator >(Fraction left, Fraction right)
        {
            double clm = lcm(left.Denumerator, right.Denumerator);
            double a = left.Numerator * clm / left.Denumerator;
            double b = right.Numerator * clm / right.Denumerator;
            return a > b;
        }
        public static bool operator <(Fraction left, Fraction right)
        {
            return !(left > right || left == right);
        }
        public static bool operator >=(Fraction left, Fraction right)
        {
            return left > right || left == right;
        }
        public static bool operator <=(Fraction left, Fraction right)
        {
            return !(left > right);
        }
        public static bool operator true(Fraction obj)
        {
            return obj.Numerator != 0;
        }
        public static bool operator false(Fraction obj)
        {
            return obj.Numerator == 0;
        }
        
       
        public static bool operator !=(Fraction left, Fraction right)
        {
            return !(left == right);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
               
            if (obj is Fraction tmp)
            {
                return this == tmp;
            }
            return false;
        }
      
    }
}