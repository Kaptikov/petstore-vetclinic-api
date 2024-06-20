using System.Text.Json.Serialization;

namespace petstore_vetclinic_api.Models.Products
{
    public class ProductCharacteristics
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }
        public ProductCharacteristicsValue? ProductCharacteristicsValue { get; set; }
        public string Name { get; set; }
    }
}
