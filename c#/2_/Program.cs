using System;

namespace _2_c_sharp
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Ex1();
            Ex2();
            Ex3();
            Ex4();
            Ex5();
            Ex6();
            Ex7();
            Ex8();
        }

        static void Ex1()
        {
            int[] arr=new int[10];
            int count = 0;
            var rand = new Random();
            Console.WriteLine("Ex1\nStarting array");
            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(10);
                Console.Write(arr[i]);
                Console.Write(" ");
            }
            Console.WriteLine();

            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i]==0)
                {
                    count++;
                }
                else
                {
                    arr[i - count] = arr[i];
                }
            }
            Array.Resize<int>(ref arr, arr.Length - count);
            Array.Resize<int>(ref arr, arr.Length + count);
            for (var i = arr.Length-count; i < arr.Length; i++)
            {
                arr[i] = -1;
            }
            Console.WriteLine("Changed array");
            for (var i= 0;  i< arr.Length; i++)
            {
                Console.Write(arr[i]);
                Console.Write(" ");
            }
            Console.WriteLine();

        }
        static void Ex2()
        {
            int[] arr = new int[10];
           
            var rand = new Random();
            Console.WriteLine("Ex2\nStarting array");
            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-5,5);
                Console.Write(arr[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
            
            Array.Sort(arr);

            Console.WriteLine("Changed array");
            for (var i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        static void Ex3()
        {
            Console.WriteLine("Ex3\nEnter array size");
            int size = int.Parse( Console.ReadLine());
            int[,] arr = new int[size,size];
            var rand = new Random();
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i,j] = rand.Next(5);
                }
            }
            Console.WriteLine("Starting array");
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j]);
                    Console.Write(" ");
                    

                }
                Console.WriteLine();
            }
            Console.WriteLine("Enter two collums to change");
            int change_1=int.Parse(Console.ReadLine());
            int change_2= int.Parse(Console.ReadLine());

            for (var i = 0; i < arr.GetLength(0); i++)
            {
                int tmp = arr[i, change_1];
                arr[i, change_1] = arr[i, change_2];
                arr[i, change_2] = tmp;
            }

            Console.WriteLine("modyfied");
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

        }

        static void Ex4()
        {
            Console.WriteLine("Ex4\nEnter string");
            string str = Console.ReadLine();
            int spaceCount = 0;
            int numbersCount = 0;
            int dotCount = 0;
            for (var i = 0; i < str.Length; i++)
            {
                if (str[i]==' ')
                {

                    spaceCount++;
                }
                else if(str[i]>='0'&&str[i]<='9')
                {
                    numbersCount++;
                }
                else if(str[i]>='!'&&str[i]<='?')
                {
                    dotCount++;
                }
            }


            Console.WriteLine("number of symbols" + str.Length);
            Console.WriteLine("number of space" + spaceCount);
            Console.WriteLine("number of numbers" + numbersCount);
            Console.WriteLine("numbers of punctuation" + dotCount);
            Console.WriteLine("number of letters" + (str.Length - spaceCount - numbersCount - dotCount));


        }
     
        static void Ex5()
        {
            Console.WriteLine("Ex5\nEnter string");
            string str = Console.ReadLine();
            Console.WriteLine("Enter char");
            char ch = Console.ReadKey().KeyChar;
            
            System.Text.StringBuilder strR = new System.Text.StringBuilder(str);

            for (var i = 0; i <str.LastIndexOf(ch); i++)
            {
                if (str[i]==ch)
                {
                    strR[i] = char.ToUpper(ch);
                }

            }
           

            
            strR.Remove(str.LastIndexOf(ch),str.Length- str.LastIndexOf(ch));
            str = strR.ToString();

            Console.WriteLine();
            Console.WriteLine("Changed string");
            Console.WriteLine(str);
        }

        static void Ex6()
        {
            Console.WriteLine("Ex6\nEnter string");
            string remove = " ";
            string str = Console.ReadLine();
           string [] split=str.Split(" ");
           
            for (var i = 0; i < split.Length; i++)
            {
                for (var j = i+1; j < split.Length; j++)
                {
                    if (split[i]==split[j])
                    {
                        split[j] = remove;
                    }
                }
            }

            str=String.Join("",split);
           
            Console.WriteLine("Changed string");
            Console.WriteLine(str);

        }

       
        static void Ex7()
        {
            Console.WriteLine("Ex6\nEnter string");
            string str = Console.ReadLine();
            string[] split = str.Split(' ');
            string first;

            for (int i = 0; i < split.Length; i++)
            {
                first = split[i][0].ToString();
                split[i] = first + split[i].Replace(first, "");
            }

            str = String.Join(" ", split);

            Console.WriteLine("Changed string");
            Console.WriteLine(str);
        }

        static string RemoveLastSymbol(string source, string symbol, int pos_s)
        {
            int pos = source.LastIndexOf(symbol);

            if (pos == pos_s)
            {
                return source;
            }
                

            if (pos == -1)
            {
                return source;
            }
                

            string result = source.Remove(pos, 1);
            return result;
        }
        static void Ex8()
        {
            string str = Console.ReadLine();
            string[] split = str.Split(' ');
            string symbol;
            for (int i = 0; i < split.Length; i++)
            {
                for (int j = 0; j < split[i].Length; j++)
                {
                    symbol = split[i][j].ToString();
                    split[i] = RemoveLastSymbol(split[i].ToString(), symbol, j);
                }
            }
            str = String.Join(" ", split);

            Console.WriteLine("Changed string");
            Console.WriteLine(str);
        }
    }

}
