using System.Text.Json.Serialization;
using petstore_vetclinic_api.Models.Products;

namespace petstore_vetclinic_api.Models.Favourites
{
    public class FavouriteItem
    {
        public int Id { get; set; }
        public int FavouriteId { get; set; }
        [JsonIgnore]
        public Favourite? Favourites { get; set; }
        public int ProductId { get; set; }
        public Product? Products { get; set; }
    }
}
