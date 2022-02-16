using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Transport[] transport = new Transport[7];
            for (int i = 0; i < transport.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        transport[i] = new Auto("Audi", 1600, rnd.Next(10000));
                        break;
                    case 1:
                        transport[i] = new PassengerAuto("Ni-ssan", 1800,  rnd.Next(10000), 6);
                        break;
                    case 2:
                        transport[i] = new Truck("KAMZA", 3000, rnd.Next(10000), 10.5);
                        break;
                    case 3:
                        transport[i] = new Plane("Not Passanger not Cargo", rnd.Next(10000));
                        break;
                        
                    case 4:
                        transport[i] = new PassengerPlane(rnd.Next(10000), 322);
                        break;
                    case 5:
                        transport[i] = new CargoPlane(rnd.Next(10000), 150);
                        break;
                    case 6:
                        transport[i] = new Train("A", rnd.Next(1000));
                        break;
                }
            }
            foreach (var item in transport)
            {
                Console.WriteLine(item.Info());
                Console.WriteLine("________________________________");
            }
        }
    }
}
