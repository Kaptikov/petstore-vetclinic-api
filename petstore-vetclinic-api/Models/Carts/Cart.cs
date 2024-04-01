using petstore_vetclinic_api.Models.Users;

namespace petstore_vetclinic_api.Models.Carts
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? Users { get; set; }
        public List<CartItem> CartItems { get; set; } = new();
    }
}
