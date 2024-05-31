using petstore_vetclinic_api.Models.Carts;
using petstore_vetclinic_api.Models.Products;
using petstore_vetclinic_api.Models.Users;
using System.Text.Json.Serialization;

namespace petstore_vetclinic_api.Models.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
       // public int ProductId { get; set; }
        // [JsonIgnore]
        // public List<Product> Products { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string? Status { get; set; }
        public decimal? TotalPrice { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
       // public List<CartItem>? CartItems { get; set; }
    }
}
