using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupaDupaConsole.Commands
{
    class CP : Icommand
    {
       

        public string Execute(string path, string endpath, string option)
        {
            if (path == endpath || path.Substring(0, path.LastIndexOf('\\')) == endpath)
            {
                Console.WriteLine("trying to copy to same directory");
                return path;
            }

            switch (option)
            {
                case "-file":
                    if (CheckOnMultiply(path))
                    {
                        CopyFile(path, endpath, path.Substring(path.LastIndexOf('\\') + 1));
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
                        CopyFile(path, endpath, path.Substring(path.LastIndexOf('\\') + 1));

                    }
                    break;
                case "-folder":
                    try
                    {
                        CopyDirectory(path, endpath);
                    }
                    catch (IOException exp)
                    {
                        Console.WriteLine(exp.Message);
                    }
                    break;
                default:
                    return path;
                    break;
            }

            return path;
            /*            if (option == "-file")
                        {
                            if (CheckOnMultiply(path))
                            {
                                CopyFile(path, endpath, path.Substring(path.LastIndexOf('\\') + 1));
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
                                CopyFile(path, endpath, path.Substring(path.LastIndexOf('\\') + 1));

                            }
                        }
                        else if (option == "-folder")
                        {
                            try
                            {
                                CopyDirectory(path, endpath);
                            }
                            catch (IOException exp)
                            {
                                Console.WriteLine(exp.Message);
                            }
                        }




                        return path;
                    }

            */
        }
        public void CopyDirectory(string path, string endpath)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            if (!directory.Exists)
            {
                Console.WriteLine("Source directory does not exist or could not be found: " + path);
                return;
            }

            DirectoryInfo[] directories = directory.GetDirectories();


            Directory.CreateDirectory(endpath);


            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(endpath, file.Name);
                file.CopyTo(tempPath, false);
            }



            foreach (DirectoryInfo sub in directories)
            {
                string tempPath = Path.Combine(endpath, sub.Name);
                CopyDirectory(sub.FullName, tempPath);
            }

        }

        public void CopyFile(string path, string endpath, string format = "")
        {
            var name = path.Substring(path.LastIndexOf('\\') + 1);
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
                        File.Copy(item, Path.Combine(endpath, Path.GetFileName(item)));
                        Console.WriteLine("{0} was copied to {1}.", item, endpath);
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
                File.Copy(item, Path.Combine(endpath, Path.GetFileName(item)));
                Console.WriteLine("{0} was copied to {1}.", item, endpath);
            }
        }



        bool CheckOnMultiply(string path)
        {
            var tmp = path.Substring(path.LastIndexOf('\\') + 1);
            if (tmp.Contains("*"))
            {
                return true;
            }
            return false;
        }
        public void Help()
        {
            Console.WriteLine("CP-Move to destenetion((-folder))(-file)");
            Console.WriteLine("CP-start path,ending path,option");
            Console.WriteLine("CP-if file didnt exist created it ");
        }
    }
}
