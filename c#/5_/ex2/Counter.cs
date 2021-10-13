using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2
{
    class Counter
    {
         public void Start()
        {
            if (new China.Pekin().GetPopulation()>new Uganda.Kampala().GetPopulation())
            {
                if (new China.Pekin().GetPopulation()>new Peru.Lima().GetPopulation())
                {
                    Console.WriteLine(new China.Pekin().GetName());
                }
                else
                {
                    Console.WriteLine(new Peru.Lima().GetPopulation());
                }
            }
            else
            {
                if (new Uganda.Kampala().GetPopulation()> new Peru.Lima().GetPopulation())
                {
                    Console.WriteLine(new Uganda.Kampala().GetPopulation());
                }
                else
                {
                    Console.WriteLine(new Peru.Lima().GetPopulation());
                }
            }
        }
    }
}
