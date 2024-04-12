using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Products;

namespace petstore_vetclinic_api.Services.ProductImgService
{
    public class ProductImgService : IProductImgService
    {
        private readonly DataContext _context;

        public ProductImgService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ProductImg>> GetAllProductImg()
        {
            var productImgs = await _context.ProductImgs.ToListAsync();
            return productImgs;
        }

        public async Task<ProductImg?> GetSingleProductImg(int id)
        {
            var productImg = await _context.ProductImgs.FindAsync(id);
            if (productImg is null)
                return productImg;

            return productImg;
        }
    }
}
