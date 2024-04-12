using System.Text.Json.Serialization;
using petstore_vetclinic_api.Models.Carts;
using petstore_vetclinic_api.Models.Categories;
using petstore_vetclinic_api.Models.Comments;
using petstore_vetclinic_api.Models.Favourites;

namespace petstore_vetclinic_api.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public string? imgUrl { get; set; }
        public int SubcategoryId { get; set; }
        [JsonIgnore]
        public Subcategory? Subcategories { get; set; }
        [JsonIgnore]
        public List<ProductImg> ProductImgs { get; set; } = new();
        [JsonIgnore]
        public List<Comment> Comments { get; set; } = new();
        [JsonIgnore]
        public List<CartItem> CartItems { get; set; } = new();
        [JsonIgnore]
        public List<FavouriteItem> FavouriteItems { get; set; } = new();
    }
}
