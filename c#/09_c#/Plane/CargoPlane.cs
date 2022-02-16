using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    class CargoPlane:Plane
    {
        public double Capacity { get; set; }
        public CargoPlane( int number, double loadCapacity) : base("Cargo",number)
        {
            Capacity = loadCapacity;
        }
        public override string Info()
        {
            return "Cargo airplane\n" + $"Appointment: {Appointment}\n" +
                $"Load capacity: {Capacity} t\n";
        }
    }
}
