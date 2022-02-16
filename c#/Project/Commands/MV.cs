using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupaDupaConsole.Commands
{
    class MV : Icommand
    {
       
        public string Execute(string path, string endpath, string option)
        {

            switch (option)
            {
                case "-file":
                    if (CheckOnMultiply(path))
                    {
                        MoveFile(path, endpath, path.Substring(path.LastIndexOf('\\') + 1));
                    }
                    else
                    {
                        //MoveFile(path, endpath);
                        if (!File.Exists(path))
                        {
                            Console.WriteLine("File {0},dosent exist\n Create ? y/n", path);
                            var tmp = Console.ReadLine();
                            if (tmp == "y")
                            {
                                using (FileStream fs = File.Create(path)) ;


                            }
                            else
                            {
                                return path;
                            }
                        }
                        MoveFile(path, endpath, path.Substring(path.LastIndexOf('\\') + 1));

                    }
                    break;

                case "-folder":
                   
                        if (Directory.Exists(endpath))
                        {
                        Console.WriteLine("{0} is alredy exist", endpath);
                        break;
                        }
                        
                        MoveFolder (path, endpath);


                    break;
                default:
                    break;
            }


           /* if (option=="-file")
            {
                if (CheckOnMultiply(path))
                {
                    MoveFile(path, endpath, path.Substring(path.LastIndexOf('\\') + 1));
                }
                else
                {
                    //MoveFile(path, endpath);
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("File {0},dosent exist\n Create ? y/n",path);
                        var tmp = Console.ReadLine();
                        if (tmp=="y")
                        {
                            using (FileStream fs = File.Create(path));


                        }
                        else
                        {
                            return path;
                        }
                    }
                        MoveFile(path, endpath, path.Substring(path.LastIndexOf('\\') + 1));

                }
            }
            else if(option=="-folder")
            {
                try
                {
                    Directory.Move(path, endpath);
                }
                catch (IOException exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }*/
            
              
            

            return path;
        }

        public void MoveFolder(string path,string endpath)
        {
           
                
                if (Directory.Exists(path) == true)
                {
                   
                    if (Directory.Exists(endpath) == false)
                    {
                        
                        Directory.Move(path, endpath);
                        Console.WriteLine("{0} was moved to {1}.", path, endpath);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Folder with same name alredy exist ");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Starting directory dosent exist ");
                }
           
            
        }
        public void MoveFile(string path, string endpath, string format="")
        {
            var name= path.Substring(path.LastIndexOf('\\') + 1);
            var tmp_path = path.Substring(0, path.LastIndexOf(@"\" + name));
          
           var files = Directory.GetFiles(tmp_path, format);
            
           

            foreach (var item in files)
            {
                if (File.Exists(Path.Combine(endpath, Path.GetFileName(item))))
                {
                    Console.WriteLine("end path file {0} with same name exist .Do you want overwrite it? \ny/n", Path.GetFileName(item));
                    var tmp = Console.ReadLine();
                    if (tmp == "y")
                    {
                        File.Delete(Path.Combine(endpath, Path.GetFileName(item)));
                        File.Move(item, Path.Combine(endpath, Path.GetFileName(item)));
                        Console.WriteLine("{0} was moved to {1}.", item, endpath);
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
                    File.Move(item, Path.Combine(endpath, Path.GetFileName(item)));
                    Console.WriteLine("{0} was moved to {1}.", item, endpath);
            }
        }
       
        bool CheckOnMultiply(string path)
        {
            var tmp = path.Substring(path.LastIndexOf('\\')+1);
            if (tmp.Contains("*"))
            {
                return true;
            }
            return false;
        }

       
        public void Help()
        {
            Console.WriteLine("MV-Move to destenetion((-folder))(-file)");
            Console.WriteLine("MV-start path,ending path,option");
            Console.WriteLine("MV-if file didnt exist created it ");
        }
    }
}
