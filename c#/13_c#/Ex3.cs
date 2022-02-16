using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collection
{
    class Ex3
    {   
        public void Work()
        {
            Console.WriteLine("Ex3.Enter Text");

            string text = Console.ReadLine();
            
            
            var counter = CountWords(text);

            var sortedByWord = counter.OrderBy(x => x.Key);
            var sortedByFrequency = sortedByWord.OrderBy(x => x.Value);

            foreach (KeyValuePair<string, int> KeyPair in sortedByFrequency)
                Console.WriteLine(KeyPair.Key+"--"+KeyPair.Value);

        }
        public static Dictionary<string, int> CountWords(string text)
        {
            Dictionary<string, int> counter = new Dictionary<string, int>();

            if (String.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("\nNull or Whitespase");
                return counter;
            }

            string[] wordArray = text.Split(new Char[] { ' ', ',', '.', '“', '”', ':', '-', '(', ')','\n' });

            foreach (string word in wordArray)
            {
                if (word.Trim() != "")
                {
                   
                        if (counter.ContainsKey(word) == false)
                            counter.Add(word, 1);
                        else
                            counter[word]++;
                    
                }

            }
            return counter;
        }
    }
}
