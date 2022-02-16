using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupaDupaConsole.Commands
{
    class RM : Icommand
    {
        

     

        public string Execute(string path, string endpath="", string option="")
        {
            switch (option)
            {
                case "-file":
                    DeleteFiles(endpath, endpath.Substring(endpath.LastIndexOf('\\') + 1));
                    break;

                case "-folder":
                    DeleteFolder(endpath);
                    break;

                default:
                    break;
            }



            return path;
        }

        public void DeleteFiles(string path, string format="")
        {
            var name = path.Substring(path.LastIndexOf('\\') + 1);
            var tmp_path = path.Substring(0, path.LastIndexOf(@"\" + name));
            
            var files = Directory.GetFiles(tmp_path, format);

            foreach (var file in files)
            {
                File.Delete(file);
                Console.WriteLine("{0} is deleted.",file);
            }

        }

        public void DeleteFolder(string path)
        {
            if (Directory.Exists(path))
            {
                DeleteFiles(path + @"\*", "*");
                Directory.Delete(path,true);
                Console.WriteLine("Folder {0} is deleted", path);
                return;
            }
            Console.WriteLine("Directory didnt exist");

            
        }
       
        public void Help()
        {
            Console.WriteLine("RM-delete file(-file) or directory(-folder)");
        }
    }
}
