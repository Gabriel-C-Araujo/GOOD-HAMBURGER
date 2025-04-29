namespace GOOD_HAMBURGER.Entity
{
    public class Sales
    {
        public int PK_Sales { get; set; }
        public int FK_Stock_IdItem { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Type { get; set; }
    }
}
