using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    class Truck : Auto
    {
        public double Capacity { get; set; }
        public Truck(string brand, double weight, int number, double loadcapacity) : base(brand, weight, number)
        {
            Capacity = loadcapacity;
        }
        public override string Info()
        {
            return "Truck\n" + $"Brand: {Brand}\n" +
                $"Engine capacity: {EngineCapacity}\n" +
                $"Load capacity: {Capacity} t\n";
        }
    }

}
