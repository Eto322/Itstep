using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_c_sharp
{


    class Shop
    {
        private Laptop[] _arr;
        public Shop(int size)
        {
            _arr = new Laptop[size];
        }
        public Shop()
        {
            _arr = new Laptop[4]
            {
                new Laptop("ASUS", 13.6, 1.26),
                new Laptop("MSI", 12.6, 2),
                new Laptop("HP", 11.6, 3.01),
                new Laptop("Lenovo", 10.6, 4),
              
            };
        }
        public int Length => _arr.Length;
        public Laptop this[int index]
        {
            get => _arr[index];
            set => _arr[index] = value;
        }
    }
}