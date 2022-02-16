using System;
using System.Collections.Generic;
using System.Linq;

namespace struct1.Struct
{
    class Rquest
    {
        private Guid Code;
        public Client Client;
        private DateTime Day;
        public List<RequestItem> ItemList;

        public Rquest(ref Client Client, List<RequestItem> ItemList)
        {
            this.Code = Guid.NewGuid();
            this.Client = Client;
            this.Day = DateTime.Today;
            this.ItemList = ItemList.Select(item => (RequestItem)item).ToList();

        }

        public float RequestSum()
        {
            float Sum = 0;
            foreach (Struct.RequestItem item in ItemList)
            {
                Sum += item.Quantity * item.RequestArticle.Price;
            }
            return Sum;
        }

        public void Work()
        {
            Console.WriteLine(Client.ToString());
            int i = 0;
            
            foreach (Struct.RequestItem item in ItemList)
            {
                i++;
                Console.WriteLine("#" + i + item);
            }
            
            Console.WriteLine("Total Sum of Request = " + RequestSum());
          
        }






    }
}
