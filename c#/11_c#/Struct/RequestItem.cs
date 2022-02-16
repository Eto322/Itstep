namespace struct1.Struct
{
    class RequestItem
    {
        public Article RequestArticle;
        public int Quantity;

        public RequestItem(Article RequestArticle, int Quantity)
        {
            this.RequestArticle = RequestArticle;
            this.Quantity = Quantity;
        }
        public override string ToString()
        {
            return string.Format("Quanity: "+Quantity+" "+RequestArticle.ToString() );
        }
    }
}
