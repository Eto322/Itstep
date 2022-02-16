using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collection
{
    class Ex2
    {
        public Dictionary<string, string> EnglishToRussian;

        public Ex2()
        {
            EnglishToRussian = new Dictionary<string, string>();
        }


        public bool Translate(string country, bool direction)
        {
            if (direction == false)
            {
                if (EnglishToRussian.ContainsKey(country) == false)
                {
                    Console.WriteLine("Key is not found.");
                    return false;
                }
                Console.WriteLine(country+"--"+EnglishToRussian[country]);
            }
            else
            {
                if (EnglishToRussian.ContainsValue(country) == false)
                {
                    Console.WriteLine("Value is not found.");
                    return false;
                }
                Console.WriteLine( country+"--"+EnglishToRussian.FirstOrDefault(x => x.Value == country).Key);
            }
            return true;
        }


        public void PrintDictionary(Dictionary<string, string> dictionary)
        {
            Console.WriteLine();
            foreach (KeyValuePair<string, string> key_pair in dictionary)
            {
                Console.WriteLine( key_pair.Key+"--"+key_pair.Value);
            }
            Console.WriteLine();
        }

        public void Work()
        {
            Ex2 dictionary = new Ex2();

                
                dictionary.EnglishToRussian.Add("Uganda", "Уганда");
                dictionary.EnglishToRussian.Add("Singapore", "Сингапур");
                dictionary.EnglishToRussian.Add("China", "Китай");
                dictionary.EnglishToRussian.Add("Ukraine", "Украина");
                dictionary.EnglishToRussian.Add("Gondor", "Гондор");

                Dictionary<string, string> Russian_to_English = dictionary.EnglishToRussian.ToDictionary(x => x.Value, x => x.Key);
                dictionary.PrintDictionary(dictionary.EnglishToRussian);
                dictionary.PrintDictionary(Russian_to_English);

            Console.WriteLine("Ex2. Dictionary");
            Console.WriteLine("\nSelect Translate diraction");
            Console.WriteLine(" 1.Russian to English\n2.English to Russian.");

            string direction_choice = Console.ReadLine();
            bool direction_check = false;
            bool direction = false;

            if (direction_choice == "1")
            {
                direction = true;
                direction_check = true;

            }
            else if (direction_choice == "2")
            {
                direction = false;
                direction_check = true;
            }


            
          
            if (direction_check == true)
            {
                while(true)
                {
                    if (direction == true)
                    {
                        Console.WriteLine("Enter country name in in Russian.");
                        
                    }
                    else
                    {
                        Console.WriteLine("Enter country name in English.");
                    }


                    string country = Console.ReadLine();

                    dictionary.Translate(country, direction);

                    Console.WriteLine("\n1-break , any key-next country");
                    string exit = Console.ReadLine();
                    if (exit == "1")
                        break;
                }
                   
                
            }
            else
            {
                Console.WriteLine("Direction is not correct.");
            }

           
        }
    }


}
