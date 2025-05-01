using System.Text.Json.Serialization;

namespace GOOD_HAMBURGER.Entity
{
    public class Sales
    {
        [JsonIgnore]
        public int PK_Sales { get; set; }
        [JsonIgnore]
        public decimal Price { get; set; }
        [JsonIgnore]
        public decimal Discount { get; set; }
        public List<SalesDetails> SalesDetails { get; set; } = new List<SalesDetails>();
    }
}
