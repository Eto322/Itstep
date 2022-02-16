using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_c_sharp
{ 
         class Laptop
        {
            string _brand;
            double _screenDiagonal;
            double _weight;
           
            public Laptop(string brand, double screenDiagonal, double weight)
            {
                _brand = brand;
                _screenDiagonal = screenDiagonal;
                _weight = weight;
                
            }
            public Laptop() : this("-1", 0, 0) { }
            public string Brand
            {
                get => _brand;
                set => _brand = value;
            }
            public double ScreenDiagonal
            {
                get => _screenDiagonal;
                set => _screenDiagonal = value;
            }
            public double Weight
            {
                get => _weight;
                set => _weight = value;
            }
           
            public override string ToString()
            {
            return $"Brand: {_brand}\n" +
                $"Screen diagonal: {_screenDiagonal}\n" +
                $"Weight: {_weight} kg\n";
                   
            }
        }
   
}
