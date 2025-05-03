//using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GOOD_HAMBURGER.Entity
{
    public class Sales
    {
        //[JsonPropertyName("idOrder")] verificar para mostrar na listorder e nao mostrar no insertorder. Para nao dar problema, deixar no ignore no momento.
        [JsonIgnore]
        public int PK_Sales { get; set; }
        [JsonIgnore]
        public decimal Price { get; set; }
        [JsonIgnore]
        public decimal Discount { get; set; }
        public List<SalesDetails> SalesDetails { get; set; } = new List<SalesDetails>();
    }
    public class SalePKDTO
    {
        public int PK_Sales { get; set; }
    }
}
