using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupaDupaConsole.Commands
{
    class Clear : Icommand
    {
        
        public string Execute(string path, string endpath="", string option="")
        {
            Console.Clear();
            return path;
        }

        public void Help()
        {
            Console.WriteLine("Clear-clear console");
        }
    }
}
