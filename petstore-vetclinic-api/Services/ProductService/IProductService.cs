using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Models.Products;
using petstore_vetclinic_api.Models.Reviews;

namespace petstore_vetclinic_api.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProduct();
        Task<Product>? GetSingleProduct(int id);
        Task<List<Product>?> SearchProductsByName(string name);
      //  Task<List<Product>?> GetProductsInSubSubcategories(int categoryId);
     ///  Task<List<Product>?> GetProductsInSubSubcategoriesBySubCategory(int categoryId);
      //  Task<List<Product>?> GetProductsInSubSubcategoriesBySubSubCategory(int categoryId);
        Task<List<Product>?> GetProductsByCategory(int categoryId);
        Task<List<Product>?> GetFilteredProducts(int categoryId, decimal? minPrice = null, decimal? maxPrice = null);
        Task<List<Product>?> SortByPriceAscending(int categoryId);
        Task<List<Product>?> SortByPriceDescending(int categoryId);
        Task<List<Product>> AddProduct(Product product);

        Task<List<Product>?> UpdateProduct(int id, Product request);

        Task<List<Product>?> DeteleProduct(int id);
        Task<Product> AddReview(Review review, int userId, int productId);
        Task<Product> DeleteReview(int reviewId, int userId);
        Task<Product> DeleteAnyReview(int reviewId);
    }
}
