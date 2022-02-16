using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhodes
{
    class Colossus
    {
        private string _name = "Colossus of Rhodes";
        private string _description = "was a statue of the Greek sun-god Helios, erected in the city of Rhodes";



        public override string ToString()
        {
            return $"Name: {_name}\n" +
                   $"Description: {_description}\n";
        }
    }
}
