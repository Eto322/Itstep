using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis

{
    class TempleOfArtemis
    {
        private string _name = "Temple of Artemis";
        private string _description = " also known as the Temple of Diana, was a Greek temple dedicated to an ancient, local form of the goddess Artemis (associated with Diana, a Roman goddess).";



        public override string ToString()
        {
            return $"Name: {_name}\n" +
                   $"Description: {_description}\n";
        }
    }
}
