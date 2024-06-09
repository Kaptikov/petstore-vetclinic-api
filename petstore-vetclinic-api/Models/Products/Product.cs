using System.Text.Json.Serialization;
using petstore_vetclinic_api.Models.Carts;
using petstore_vetclinic_api.Models.Categories;
using petstore_vetclinic_api.Models.Favourites;
using petstore_vetclinic_api.Models.Reviews;

namespace petstore_vetclinic_api.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public int? Article {  get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? OldPrice { get; set; }
        public int? Discount { get; set; }
        public string? imgUrl { get; set; }
     //   public FavouriteItem FavouriteItem { get; set; }
        public ProductAdvantage ProductAdvantage { get; set; }
        public ProductDescription ProductDescription { get; set; }
        public ProductComposition ProductComposition { get; set; }
        public ProductCharacteristics ProductCharacteristic { get; set; }
        public ProductNutritionalValue ProductNutritionalValue { get; set; }
        public int CategoryId { get; set; }
        public Category? Categories { get; set; }
        [JsonIgnore]
        public List<ProductImg> ProductImgs { get; set; } = new();
  
        public List<Review> Reviews { get; set; } = new();
        [JsonIgnore]
        public List<CartItem> CartItems { get; set; } = new();
        [JsonIgnore]
        public List<FavouriteItem> FavouriteItems { get; set; } = new List<FavouriteItem>();
    }
}
