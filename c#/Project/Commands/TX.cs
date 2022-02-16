using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupaDupaConsole.Commands
{
    class TX : Icommand
    {
       
     

        public void ReadTXT(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
               
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

        }

        public void StartWrite(string path)
        {
            if (!File.Exists(path))
            {
                
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(Console.ReadLine());
                }
            }
            else
            {
                new RM().DeleteFiles(path, path.Substring(path.LastIndexOf('\\') + 1)); 
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(Console.ReadLine());
                }

            }
        }

        public void EndWrite(string path)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(Console.ReadLine());
            }
        }
        public string Execute(string path, string endpath="", string option="-read")
        {
            
            
                switch (option)
                {
                    case "-read":
                        ReadTXT(endpath);
                        break;

                    case "-sw":
                        StartWrite(endpath);
                        break;
                    case "-ew":
                        EndWrite(endpath);
                        break;
                    default:
                        break;
                }
            
           


            return path;
        }

        public void Help()
        {
            Console.WriteLine("TX-read(-read) or write to file(-sw write from start(override file if dosent exist create it ),-ew write from end)");
        }
    }
}
