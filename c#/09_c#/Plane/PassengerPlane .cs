using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    class PassengerPlane :Plane
    {
        public int Seats { get; set; }
        public PassengerPlane( int number, int numberOfSeats) : base("Passenger", number)
        {
            Seats = numberOfSeats;
        }
        public override string Info()
        {
            return "Passenger " + base.Info() + $"Number of seats: {Seats}\n";
        }
    }
}
