using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupaDupaConsole.Commands
{
   interface Icommand
    {
        
        string Execute(string path, string endpath, string option);
        void Help();
    }
}
