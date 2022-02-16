using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SupaDupaConsole.Commands
{
    class LS : Icommand
    {
      

        public string Execute(string path, string endpath="", string option="*")
        {
            var filePaths = Directory.GetFileSystemEntries(path, option);

            foreach (var file in filePaths)
            {
                var tmp = file.Substring(file.LastIndexOf('\\') + 1);
                Console.WriteLine(tmp);

            }
            return path;
        }

        public void Help()
        {
            Console.WriteLine("List  information  about  the  FILEs  (the  current  directory  by default).");
        }
    }
}
