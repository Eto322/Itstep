using System;
using dz6.InfoStructure;

namespace dz6.Model
{
    public class Human:BaseNotify
    {
        private string _name;
        private string _secondName;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                Notify(nameof(Name));
            }
        }
        public string SecondName {
            get => _secondName;
            set
            {
                _secondName = value;
               Notify(nameof(SecondName));
            }
        }
        public Human()
        {
            _name = String.Empty;
            _secondName = String.Empty;
        }
        public Human(string name, string secondName)
        {
            _name = name;
            _secondName = secondName;
        }
        public override string ToString()
        {
            return $"{Name} {SecondName}";
        }
    }
}