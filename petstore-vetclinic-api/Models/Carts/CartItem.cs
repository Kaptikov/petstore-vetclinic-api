using System.Text.Json.Serialization;
using petstore_vetclinic_api.Models.Orders;
using petstore_vetclinic_api.Models.Products;
using petstore_vetclinic_api.Models.Users;

namespace petstore_vetclinic_api.Models.Carts
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public Product? Products { get; set; }
        public int UserId { get; set; }
        public User? Users { get; set; }
      //  public int? OrderId { get; set; }
        //[JsonIgnore]
        //public Order? Orders { get; set; }
    }
}
