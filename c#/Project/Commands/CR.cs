using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupaDupaConsole.Commands
{
    class CR : Icommand
    {
        



        public string Execute(string path, string endpath="", string option="")
        {
            switch (option)
            {
                case "-file":
                    if (File.Exists(path+ @"\" + endpath))
                    {
                        Console.WriteLine("That File exists already.");
                        return path;
                    }
                    using (FileStream fs = File.Create(path + @"\" + endpath)) ;
                    Console.WriteLine("The file was created  at {0}.", path);
                    break;

                case "-folder":
                    if (Directory.Exists(path+@"\"+endpath))
                    {
                        Console.WriteLine("That Directory exists already.");
                        return path;
                    }

                    Directory.CreateDirectory(path+ @"\" + endpath);
                    Console.WriteLine("The directory was created at {0}.", path);

                    break;
                default:
                    break;
            }
            return path;
        }

        public void Help()
        {
            Console.WriteLine("CR-create file(-file) or folder(-folder) in current directory");
        }
    }
}
