namespace petstore_vetclinic_api.Models.Products
{
    public class ProductComposition
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public string Composition { get; set; }
    }
}
