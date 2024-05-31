using petstore_vetclinic_api.Models.Products;
using System.Text.Json.Serialization;

namespace petstore_vetclinic_api.Models.Categories
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public string? ImgUrl { get; set; }
        [JsonIgnore]
        public Category? ParentCategory { get; set; }
       // [JsonIgnore]
        public List<Category> ChildCategories { get; set; } = new();
        [JsonIgnore]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
