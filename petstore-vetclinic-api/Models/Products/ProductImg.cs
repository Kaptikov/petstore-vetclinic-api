namespace petstore_vetclinic_api.Models.Products
{
    public class ProductImg
    {
        public int Id { get; set; }
        public string? imgUrl { get; set; }
        public int ProductId { get; set; }
        public Product? Products { get; set; }
    }
}
