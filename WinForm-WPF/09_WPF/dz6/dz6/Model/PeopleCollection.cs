using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz6.Model
{
    [Serializable]
    public class PeopleCollection
    {


        public PeopleCollection()
        {
            peoples = new ObservableCollection<People>();
        }

        public PeopleCollection(ObservableCollection<People> peoples)
        {
            this.peoples = peoples;
        }

        public ObservableCollection<People> peoples { get; set; }
    }
}
