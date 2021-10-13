using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giza
{
    class GizaPiramide
    {
        private string _name = "Giza Piramide";
        private string _description = "Giza Piramide is the oldest and largest of the pyramids";

        

        public override string ToString()
        {
            return $"Name: {_name}\n" +
                   $"Description: {_description}\n";
        }
    }
}
