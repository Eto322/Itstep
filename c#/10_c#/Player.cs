using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Player : Iobserver
    {
        private string Name { get; }

        public Player(string s)
        { Name = s; }

        public void update(string massage)
        {
            Console.WriteLine("Name: " + Name + "\t" + massage);
        }
        
    }
}
