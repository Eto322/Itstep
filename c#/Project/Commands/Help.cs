using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupaDupaConsole.Commands
{
    class Help : Icommand
    {
        Dictionary<string, Icommand> dictionary = new CommandDictionary().HelpDict();
        public string Execute(string path, string endpath, string option)
        {

            dictionary[option.Substring(option.IndexOf('-')+1)].Help();
            return path;
        }



        void Icommand.Help()
        {
            Console.WriteLine("write command help -name of command");
            Console.WriteLine("cd\nClear\ncp\ncr\nls\nlsattr\nmv\nrm\tx");

        }
    }
}
