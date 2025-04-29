namespace GOOD_HAMBURGER.Entity
{
    public class Stock
    {
        public int PK_Stock {  get; set; }
        public string Product {  get; set; }
        public int Quantity {  get; set; }
        public decimal Price { get; set; }
        public int Type { get; set; }
        public string TypeDescription { get; set; }
    }
}
