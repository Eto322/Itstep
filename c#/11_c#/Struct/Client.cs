using System;

namespace struct1.Struct
{
    struct Client
    {
        private Guid Code { get; }
        private string Name { get; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public int OrdersQuantity { get; set; }
        public float TotalOrdersSum { get; set; }

        public Client(string Name, string Address, string Phone, int OrdersQuantity, float TotalOrdersSum)
        {
            this.Code = Guid.NewGuid();
            this.Name = Name;
            this.Address = Address;
            this.Phone = Phone;
            this.OrdersQuantity = OrdersQuantity;
            this.TotalOrdersSum = TotalOrdersSum;
        }

        public override string ToString()
        {
            return "Name: " + Name + " Adress: " + Address + " Phone:  " + Phone + " #Oreder: " + OrdersQuantity
                + " Total sum: " + TotalOrdersSum;
        }
    }
}
