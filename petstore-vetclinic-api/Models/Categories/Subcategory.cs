using petstore_vetclinic_api.Models.Products;

namespace petstore_vetclinic_api.Models.Categories
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        //[JsonIgnore]
        public Category? Categories { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}
