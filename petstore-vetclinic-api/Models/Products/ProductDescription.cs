namespace petstore_vetclinic_api.Models.Products
{
    public class ProductDescription
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public string Description { get; set; }
    }
}
