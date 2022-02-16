using System;

namespace struct1.Struct
{
    struct Article
    {
        private Guid Code { get; }
        private string Name { get; set; }
        public float Price { get; set; }
        private ArticleType Type;
        public enum ArticleType
        {
            Foods, Technic, Clothes
        }
        public Article(string Name, float Price, Article.ArticleType Type)
        {
            this.Code = Guid.NewGuid();
            this.Name = Name;
            this.Price = Price;
            this.Type = Type;
        }

        public override string ToString()
        {
            string str = Code.ToString();
            return "Name: " + Name + " Price " + Price;
        }


    }
}
