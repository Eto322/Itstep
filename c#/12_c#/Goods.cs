using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace delegate_
{
    class Ex1
    {
        public struct Goods
        {
            public string Code;
            public string Name;
            public float Price;
            public GoodsType Type;

            public enum GoodsType
            {
                Technic, Foods, Clothes
            }

            public Goods(string Code, string Name, float Price, Goods.GoodsType Type)
            {
                this.Code = Code;
                this.Name = Name;
                this.Price = Price;
                this.Type = Type;
            }

            public override string ToString()
            {
                return ("Code " + Code + " Name " + Name + "Price " + Price + " Type " + Type);
            }
        }

        static public void Find(Object[] array, Comparer comparer)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                if (comparer(array[i]))
                {
                    Console.WriteLine(i + " " + array[i]);
                }
            }
        }

        public delegate Boolean Comparer(Object elem1);

        static public Boolean NameComparer(Object goods)
        {
            return ((Goods)goods).Name == "T-shirt";
        }

        static public Boolean CodeComparer(Object goods)
        {
            return ((Goods)goods).Code == "245";
        }

        static public Boolean TypeComparer(Object goods)
        {
            return ((Goods)goods).Type == Goods.GoodsType.Clothes;
        }



        public void Work()
        {
            Goods goods1 = new Goods("127", "Orange", 12.5F, Goods.GoodsType.Foods);
            Goods goods2 = new Goods("245", "Phone", 2000.90F, Goods.GoodsType.Technic);
            Goods goods3 = new Goods("421", "Red Apples", 4.20F, Goods.GoodsType.Foods);
            Goods goods4 = new Goods("178", "Hat", 143.62F, Goods.GoodsType.Clothes);
            Goods goods5 = new Goods("124", "T-shirt", 330F, Goods.GoodsType.Clothes);
            Goods goods6 = new Goods("456", "T-shirt", 200.90F, Goods.GoodsType.Clothes);

            Object[] GoodsArray = { goods1, goods2, goods3, goods4, goods5, goods6 };
            uint i = 0;
            foreach (Object goods in GoodsArray)
            {
                Console.WriteLine(i + " " + goods);
                i++;
            }
            Console.WriteLine();

            Console.WriteLine("Find Code 245 ");
            Find(GoodsArray, new Comparer(CodeComparer));

            Console.WriteLine("\n\n\nFind Clothes");
            Find(GoodsArray, new Comparer(TypeComparer));
            Console.WriteLine();

            Console.WriteLine("Find T-shirts");
            Find(GoodsArray, new Comparer(NameComparer));


        }
    }
}