using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympia

{
    class ZeusStatue
    {
        private string _name = "Statue of Zeus at Olympia";
        private string _description = "The Statue of Zeus at Olympia was a giant seated figure, about 12.4 m (41 ft) tall,[1] made by the Greek sculptor Phidias around 435 BC at the sanctuary of Olympia, Greece, and erected in the Temple of Zeus there. Zeus is the sky and thunder god in ancient Greek religion, who rules as king of the gods of Mount Olympus.";



        public override string ToString()
        {
            return $"Name: {_name}\n" +
                   $"Description: {_description}\n";
        }
    }
}