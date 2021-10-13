using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Mausoleum

{
        class Halicarnassus
    {
            private string _name = "Mausoleum At Halicarnassus";
            private string _description = " was a tomb built between 353 and 350 BC in Halicarnassus (present Bodrum, Turkey) for Mausolus,";



            public override string ToString()
            {
                return $"Name: {_name}\n" +
                       $"Description: {_description}\n";
            }
        }
}

