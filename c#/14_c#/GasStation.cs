using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_
{
    class GasStation
    {
        public string Mark { get; set; }
        public int Price { get; set; }
        public string Company { get; set; }
        public string Street { get; set; }

        public GasStation(string Mark,int Price,string Company, string Street)
        {
            this.Mark = Mark;
            this.Price = Price;
            this.Company = Company;
            this.Street = Street;

        }

        public override string ToString()
        {
            return Mark + " " + Price + "kop " + Company + " " + Street;
        }

    }
}
