using System.Text.Json.Serialization;
namespace GOOD_HAMBURGER.Entity
{
    public class SalesDetails
    {
        [JsonIgnore]
        public int PK_SalesDetails { get; set; }

        [JsonIgnore]
        public int FK_Sales { get; set; }
        
        [JsonPropertyName("IdItem")]
        public int FK_Stock_IdItem { get; set; }

        [JsonPropertyName("Quantity")]
        public int Quantity { get; set; }

        [JsonIgnore]
        public decimal Price { get; set; }

        [JsonIgnore]
        public decimal Discount { get; set; }

        [JsonIgnore]
        public int Type { get; set; }
    }
    public class SaleTypeDTO
    {
        public int Type { get; set; }
    }
}
