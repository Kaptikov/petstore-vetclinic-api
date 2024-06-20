using System.Text.Json.Serialization;

namespace petstore_vetclinic_api.Models.Products
{
    public class ProductCharacteristicsValue
    {
        public int Id { get; set; }
        public int ProductCharacteristicsId { get; set; }
        [JsonIgnore]
        public ProductCharacteristics? ProductCharacteristics { get; set; }
        public string Name { get; set; }
    }
}
