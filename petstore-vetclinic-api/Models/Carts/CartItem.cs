using System.Text.Json.Serialization;
using petstore_vetclinic_api.Models.Products;

namespace petstore_vetclinic_api.Models.Carts
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        [JsonIgnore]
        public Cart? Carts { get; set; }
        public Product? Products { get; set; }
    }
}
