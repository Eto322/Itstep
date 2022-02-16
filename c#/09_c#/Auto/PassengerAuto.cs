using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    class PassengerAuto:Auto
    {
        public int Seats { get; set; }
        public PassengerAuto(string brand, double weight,  int number, int seats) : base(brand, weight,number)
        {
            Seats = seats;
        }
        public override string Info()
        {
            return "Passenger " + base.Info() + $"Number of seats: {Seats}\n";
        }
    }
}
