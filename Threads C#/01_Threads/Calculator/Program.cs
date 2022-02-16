using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Calculator
{

    
    internal class Program
    {
        static void Main(string[] args)
        {

            
           

            if (args.Length==0)
            {
                Console.WriteLine("No parameters was entered");
                Console.ReadKey();//readkey были добавлени , посколку я не придумал как решить проблему что при запуске с формы он сразу закрывался 

            }
            else if (args.Length>1)
            {
                string joinstring= string.Join(' ', args);

                

              joinstring=joinstring.Replace(" ",string.Empty);

              Console.WriteLine((decimal)new DataTable().Compute(joinstring, null));
              Console.ReadKey();




            }
            else
            {
                Console.WriteLine((decimal)new DataTable().Compute(args[0], null));
                Console.ReadKey();

            }

           





        }
    }
}
