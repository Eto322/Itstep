using System;
using dz6.InfoStructure;

namespace dz6.Model
{
    [Serializable]
    public class People:BaseNotify
    {
        private string _name;
        private string _surname;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                Notify(nameof(Name));
            }
        }


        public People(string name, string surname)
        {
            _name = name;
            _surname = surname;
        }
        public string Surname {
            get => _surname;
            set
            {
                _surname = value;
               Notify(nameof(Surname));
            }
        }
        public People()
        {
            _name = String.Empty;
            _surname = String.Empty;
        }
       
        public override string ToString()
        {
            return Name+" "+Surname;
        }
    }
}