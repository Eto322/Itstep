using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface Iobservers
    {
        void add(Iobserver player);
        void remove(Iobserver player);
        void notify(string player);

        List<Iobserver> ob {get; set;}
        

    }
}
