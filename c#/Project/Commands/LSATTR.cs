using System;
using System.IO;

namespace SupaDupaConsole.Commands
{
    internal class LSATTR : Icommand
    {
        

        public string Execute(string path, string endpath="", string option="")
        {
            if (!File.Exists(endpath))
            {
                Console.WriteLine("LSATTR File Didnt exist");
                return path;
            }


            Console.WriteLine("is ReadOnly=" + ((File.GetAttributes(path) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly));

            Console.WriteLine("is isHidden=" + ((File.GetAttributes(path) & FileAttributes.Hidden) == FileAttributes.Hidden));

            Console.WriteLine("is isArchive=" + ((File.GetAttributes(path) & FileAttributes.Archive) == FileAttributes.Archive));

            Console.WriteLine("is isSystem=" + ((File.GetAttributes(path) & FileAttributes.System) == FileAttributes.System));

            return path;
        }

        public void Help()
        {
            Console.WriteLine("lsattr - show attributes of file ");
        }
    }
}