using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    class Transport
    {
        public int Registration { get; set; }
        public Transport(int Registration)
        {
            this.Registration = Registration;
        }
        public virtual string Info()
        {
            return "Transport\n" + $"Transport registration number: {Registration}\n";
        }
    }
}