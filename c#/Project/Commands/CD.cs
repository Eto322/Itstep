using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupaDupaConsole.Commands
{
    class CD : Icommand
    {
       
       

        public string Execute(string path, string endpath="", string option="")
        {
          
             if (endpath != "")
            {
                var check = endpath;
                return endpath;
            }
            
            return path;
        }

        public void Help()
        {
            Console.WriteLine("cd \n Change the  working directory.");
        }
    }
}
