using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Chat:Iobservers
    {
        public Chat()
        {
            ob = new List<Iobserver>();
        }
        public List<Iobserver> ob { get; set; }
        public void  add(Iobserver s)
        {
            ob.Add(s);  
        }

        public void notify(string massage)
        {
            foreach(var observer in ob)
            {
                observer.update(massage);
            }
        }

        public void remove(Iobserver s)
        {
            ob.Remove(s);
        }
    }
}
