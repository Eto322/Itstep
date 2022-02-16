using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_5
{
    [Serializable]
    public class Goods
    {
        public Goods(string name, string manufactor, string manufactorCountry, string uKTZ, double price, bool garanty,  string photo)
        {
            Name = name;
            Manufactor = manufactor;
            ManufactorCountry = manufactorCountry;
            UKTZ = uKTZ;
            Price = price;
            Garanty = garanty;
            ID = Guid.NewGuid();
            Photo = photo;
        }

        public Goods()
        {

        }
        public string Name { get; set; }
        public string Manufactor { get; set; }
        public string ManufactorCountry { get; set; }

        public string UKTZ { get; set; }

        public double Price { get; set; }

        public bool Garanty { get; set; }

        public Guid ID { get; set; }

        public string Photo { get; set; }

        public string get_info()
        {
            return "Name: " + Name + "\nPrice: " + Price + "\nManufactor: " + Manufactor + "\nManufactor country:" + ManufactorCountry +
                "\nUKTZ: " + UKTZ + "\nGaranty: " + Garanty;
        }
        public override string ToString()
        {
            return Name + " " + Price + " UAH";
        }


    }
}
