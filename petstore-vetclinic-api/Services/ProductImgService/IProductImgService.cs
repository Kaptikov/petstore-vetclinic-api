using petstore_vetclinic_api.Models.Products;

namespace petstore_vetclinic_api.Services.ProductImgService
{
    public interface IProductImgService
    {
        Task<List<ProductImg>> GetAllProductImg();
        Task<ProductImg>? GetSingleProductImg(int id);
    }
}
