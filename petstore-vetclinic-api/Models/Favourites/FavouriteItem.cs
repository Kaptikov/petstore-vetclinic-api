using System.Text.Json.Serialization;
using petstore_vetclinic_api.Models.Products;
using petstore_vetclinic_api.Models.Users;

namespace petstore_vetclinic_api.Models.Favourites
{
    public class FavouriteItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? Users { get; set; }
        public int ProductId { get; set; }
        public Product? Products { get; set; }
    }
}
