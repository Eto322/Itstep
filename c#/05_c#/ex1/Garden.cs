using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babylon

{
    class Garden
    {
        private string _name = "Hanging Gardens of Babylon";
        private string _description = "They were described as a remarkable feat of engineering with an ascending series of tiered gardens containing a wide variety of trees, shrubs, and vines, resembling a large green mountain constructed of mud bricks. ";



        public override string ToString()
        {
            return $"Name: {_name}\n" +
                   $"Description: {_description}\n";
        }
    }
}
