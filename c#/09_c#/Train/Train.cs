using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    class Train : Transport
    {
        public string Classification { get; set; }
        public int TrainNumber { get; set; }
        public Train(string trainClassification, int registration) : base(registration)
        {
            Classification = trainClassification;
           
        }
        public override string Info()
        {
            return "Train\n" + $"Train classification: {Classification}\n" +
                $"Train number: {TrainNumber}\n" +
                $"Registration number: {Registration}\n";
        }
    }
}

