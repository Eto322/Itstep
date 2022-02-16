using System;
using System.Collections.Generic;

namespace SupaDupaConsole.Commands
{
    internal class CommandDictionary
    {
        public Dictionary<string, Icommand> Dictionary()
        {
            var tmp = new Dictionary<string, Icommand>
            {  {"cd",new CD()},
               {"clear",new Clear()},
               {"cp",new CP()},
               {"cr",new CR()},
               {"ls",new LS()},
               {"lsattr",new LSATTR()},
               {"mv",new MV()},
               {"rm",new RM()},
               {"tx",new TX()},
               {"help",new Help() }
            };

            

            return tmp;
        }

        public Dictionary<string, Icommand> HelpDict()
        {
            var tmp = new Dictionary<string, Icommand>
            {  {"cd",new CD()},
               {"clear",new Clear()},
               {"cp",new CP()},
               {"cr",new CR()},
               {"ls",new LS()},
               {"lsattr",new LSATTR()},
               {"mv",new MV()},
               {"rm",new RM()},
               {"tx",new TX()},
            };

            return tmp;
        }
    }
}