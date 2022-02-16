using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    class Auto : Transport
    {
        public string Brand { get; set; }
        public double EngineCapacity { get; set; }
        public Auto(string brand,  double engine, int registration) : base(registration)
        {
            Brand = brand;
            EngineCapacity = engine;
        }
        public override string Info()
        {
            return "Automobile\n" +
                $"Brand: {Brand}\n" +
                $"Engine capacity: {EngineCapacity}\n" +
                $"Registration number: {Registration}\n";
        }
    }
}