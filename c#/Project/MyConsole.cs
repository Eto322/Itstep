using SupaDupaConsole.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupaDupaConsole
{
    class MyConsole
    {
        public void EnterPoint()
        {
            var history = new List<string>();
            string WorkingPath = Directory.GetCurrentDirectory();
            var dictionary = new CommandDictionary().Dictionary();
            
            

            while (true)
            {
                
                Console.WriteLine(WorkingPath);
                string command = Console.ReadLine();
                history.Add(command);


                if (command == "exit")
                {
                    break;
                }
                if (command == "history")
                {
                    history.ForEach(Console.WriteLine);
                }

                if (!dictionary.ContainsKey(GetCommand(command)))
                {
                    Console.WriteLine("Command didnt exist try help{help -command send help}");
                    break;
                }
                
                

               
                if (Pathcheck(command)>3||1< Pathcheck(command))
                {
                    Console.WriteLine("Command didnt exist try help{help -command send help}");
                    break;
                }
                

                try
                {
                    if (Pathcheck(command)==3||command.Contains("help"))
                    {
                        /* var check = GetPart(command,0);
                        var check2 = GetPart(command,1);
                        var check1 = GetPart(command,2);
                        var check3 = GetPart(command,3);*/

                        if (GetPart(command, 2).StartsWith("\\"))
                        {
                            dictionary[GetPart(command, 0)].Execute(WorkingPath + GetPart(command, 2), GetPart(command, 3), GetPart(command, 1));
                        }
                        else
                        {
                            dictionary[GetPart(command, 0)].Execute(GetPart(command, 2), GetPart(command, 3), GetPart(command, 1));
                        }
                    }
                    else if (GetPath(command).StartsWith("\\"))
                    {
                       
                        
                       

                        WorkingPath = dictionary[GetCommand(command)].Execute(WorkingPath, WorkingPath + GetPath(command), GetOption(command));
                    }
                    else

                    {
                        
                        WorkingPath = dictionary[GetCommand(command)].Execute(WorkingPath, GetPath(command), GetOption(command));
                    }



                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                    break;
                }
                
            }
            
            new OPENINGGODA().opening();

            //Console.WriteLine(WorkingPath);
        }

      public string GetCommand(string path)
       {
            if (path.Contains(" "))
            {
                return path.Substring(0, path.IndexOf(" "));
            }
            return path;
            
       }

       public string GetOption(string path)
        {
            if (!path.Contains("-"))
            {
                return "";
            }
            int lenght = path.LastIndexOf(" ") - path.IndexOf(" ");

            return path.Substring(path.IndexOf(" ")+1,lenght-1) ;
        }

        public string GetPath(string path)
        {
            if (!path.Contains(" "))
            {
                return "";
            }

            if (GetOption(path)=="")
            {
                int lenghtt = path.LastIndexOf("\0")-path.IndexOf(" ");

                return path.Substring(path.IndexOf(" ") + 1, lenghtt);
            }
            int lenght = path.LastIndexOf("\0")-path.LastIndexOf(" ");
            return path.Substring(path.LastIndexOf(" ")+1, lenght);
        }

       public int Pathcheck(string path)
       {
            int count = path.Count(x => x ==' ');

            return count;
            
           
       }

        
        public string GetPart(string path ,int i)
        {
            var split = path.Split(" ");
            return split[i];
        }
        

        
    }
}
