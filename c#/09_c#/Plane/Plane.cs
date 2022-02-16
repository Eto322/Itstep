using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    class Plane:Transport
    {
        public string Appointment { get; set; }
        
        public Plane(string appointment, int registration) : base(registration)
        {
            Appointment = appointment;
            
        }
        public override string Info()
        {
            return "Plane\n" + $"Appointment: {Appointment}\n" +
                $"Registration number: {Registration}\n";
        }
    }
}

