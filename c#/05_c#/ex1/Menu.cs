using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    class Menu
    {
       public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.Great Pyramid of Giza\n 2.Hanging Gardens of Babylon\n 3.Temple of Artemis\n 4.Statue of Zeus at Olympia\n 5.Mausoleum at Halicarnassus\n 6.Colossus of Rhodes\n 7.Lighthouse of Alexandria\n");

                string k;
                k = Console.ReadLine();
                switch (k)
                {
                    case "1":
                        Console.WriteLine(new Giza.GizaPiramide().ToString());
                        break;
                    case "2":
                        Console.WriteLine(new Babylon.Garden().ToString());
                        break;
                    case "3":
                        Console.WriteLine(new Artemis.TempleOfArtemis().ToString());
                        break;
                    case "4":
                        Console.WriteLine(new Olympia.ZeusStatue().ToString());
                        break;
                    case "5":
                        Console.WriteLine(new Mausoleum.Halicarnassus().ToString());
                        break;
                    case "6":
                        Console.WriteLine(new Rhodes.Colossus().ToString());
                        break;
                    case "7":
                        Console.WriteLine(new Alexandria.Lighthouse().ToString());
                        break;

                    default:
                        return;  
                        break;
                }
                Console.WriteLine("Press enter to continue");
                Console.ReadKey();
                
            }
            
        }
    }
}
