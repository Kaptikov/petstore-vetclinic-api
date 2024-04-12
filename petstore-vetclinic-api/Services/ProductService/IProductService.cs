using petstore_vetclinic_api.Models.Products;

namespace petstore_vetclinic_api.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProduct();
        Task<Product>? GetSingleProduct(int id);

        Task<List<Product>> AddProduct(Product product);

        Task<List<Product>?> UpdateProduct(int id, Product request);

        Task<List<Product>?> DeteleProduct(int id);
    }
}
