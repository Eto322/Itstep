using System;
using System.Collections.Generic;


namespace struct1
{



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Article");
            Struct.Article article1 = new Struct.Article("Meat", 20, Struct.Article.ArticleType.Foods);
            Struct.Article article2 = new Struct.Article("Jeans", 17.7F, Struct.Article.ArticleType.Clothes);
            Struct.Article article3 = new Struct.Article("Phone", 1300, Struct.Article.ArticleType.Technic);

            Console.WriteLine(article1);
            Console.WriteLine(article2);
            Console.WriteLine(article3);
            Console.WriteLine();

            Console.WriteLine("Client");
            Struct.Client client1 = new Struct.Client("Alejik Lazutkin", "Avenue 1337 house 322", "(23)(333-333-331)", 4, 1100);

            Console.WriteLine(client1);
            Console.WriteLine();


            Console.WriteLine("Request Items");
            Struct.RequestItem item1 = new Struct.RequestItem(article1, 1);
            Struct.RequestItem item2 = new Struct.RequestItem(article2, 1);
            Struct.RequestItem item3 = new Struct.RequestItem(article3, 1);

            Console.WriteLine(item1);
            Console.WriteLine(item2);
            Console.WriteLine(item3);


            Console.WriteLine();



            Console.WriteLine("Request");

            List<Struct.RequestItem> ItemList1 = new List<Struct.RequestItem>();
            ItemList1.Add(item1);
            ItemList1.Add(item2);
            ItemList1.Add(item3);

            Struct.Rquest request1 = new Struct.Rquest(ref client1, ItemList1);
            request1.Work();
            
            
        }
    }

}
