using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexandria
{
    class Lighthouse

    {
        private string _name = "Lighthouse of Alexandria";
        private string _description = " The Lighthouse of Alexandria, sometimes called the Pharos of Alexandria";



        public override string ToString()
        {
            return $"Name: {_name}\n" +
                   $"Description: {_description}\n";
        }
    }
}
