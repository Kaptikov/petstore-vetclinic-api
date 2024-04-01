using petstore_vetclinic_api.Models.Users;

namespace petstore_vetclinic_api.Models.Favourites
{
    public class Favourite
    {
        public int Id { get; set; }
        // public int? UserId { get; set; }
        public int UserId { get; set; }
        public User? Users { get; set; }
        public List<FavouriteItem> FavouriteItems { get; set; } = new();
    }
}
