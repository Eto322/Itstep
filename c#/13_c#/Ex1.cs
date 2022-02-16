using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collection
{
    class Ex1
    {
        public class IntCollection : List<int> { } // можно вот так в одну строку 



        class CharCollection : CollectionBase   //украл с msdn(https://docs.microsoft.com/ru-ru/dotnet/api/system.collections.collectionbase?redirectedfrom=MSDN&view=net-5.0)   
        {
            public char this[int index]
            {
                get
                {
                    return ((char)List[index]);
                }
                set
                {
                    List[index] = value;
                }
            }

            public void Add(char value)
            {
                List.Add(value);
            }
        }



       public void Work()
        {
            Console.WriteLine("Ex1.list");
            Console.WriteLine("Int list");
            IntCollection int_list = new IntCollection();

            for (int i = 0; i < 9; i++)
            {   //int_list.Add("A")- ошибочка
                int_list.Add(i);
            }
            foreach (byte i in int_list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();




            Console.WriteLine("Char list");
            CharCollection char_list = new CharCollection();

            //char_list.Add(5.4);-ошибочка
            char_list.Add('a');
            char_list.Add('A');
            

            foreach (char i in char_list)
            {
                Console.WriteLine( i);
            }
            Console.WriteLine();

        }
    }
}

