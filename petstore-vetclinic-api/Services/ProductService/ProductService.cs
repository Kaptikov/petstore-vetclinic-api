using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Animals;
using petstore_vetclinic_api.Models.Categories;
using petstore_vetclinic_api.Models.Products;
using petstore_vetclinic_api.Models.Reviews;

namespace petstore_vetclinic_api.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>?> DeteleProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is null)
                return null;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetAllProduct()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<List<Product>> SearchProductsByName(string name)
        {
            var products = await _context.Products.Where(p => p.Name.Contains(name)).ToListAsync();
            return products;
        }

        public async Task<Product?> GetSingleProduct(int id)
        {
            var product = await _context.Products.Include(p => p.Reviews).ThenInclude(u => u.Users).FirstOrDefaultAsync(p => p.Id == id);
            if (product is null)
                return product;

            return product;
        }

     /*   public async Task<List<Product>?> GetProductsInSubSubcategories(int categoryId)
        {
            var products = new List<Product>();

            var category = await _context.Categories
                .Include(c => c.ChildCategories)
                .ThenInclude(c => c.ChildCategories)
                .ThenInclude(p => p.Products)
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category != null)
            {
                products.AddRange(category.Products);

                foreach (var subcategory in category.ChildCategories)
                {
                    products.AddRange(subcategory.Products);

                    foreach (var subsubcategory in subcategory.ChildCategories)
                    {
                        products.AddRange(subsubcategory.Products);
                    }
                }
            }

            return products;
        }

        public async Task<List<Product>?> GetProductsInSubSubcategoriesBySubCategory(int categoryId)
        {
            var products = new List<Product>();

            var category = await _context.Categories
                .Include(c => c.ChildCategories)
                .ThenInclude(p => p.Products)
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category != null)
            {
                products.AddRange(category.Products);

                foreach (var subcategory in category.ChildCategories)
                {
                    products.AddRange(subcategory.Products);

                    foreach (var subsubcategory in subcategory.ChildCategories)
                    {
                        products.AddRange(subsubcategory.Products);
                    }
                }
            }

            return products;
        }

        public async Task<List<Product>> GetProductsInSubSubcategoriesBySubSubCategory(int categoryId)
        {
            var products = new List<Product>();

            var subsubcategory = await _context.Categories
                .Include(p => p.Products)
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            if (subsubcategory != null)
            {
                products.AddRange(subsubcategory.Products);
            }

            return products;
        }
        */
      
        public async Task<List<Product>?> GetProductsByCategory(int categoryId)
        {
            var products = new List<Product>();

            var category = await _context.Categories
                .Include(c => c.ChildCategories)
                    .ThenInclude(c => c.ChildCategories)
                        .ThenInclude(p => p.Products)
                .Include(c => c.ChildCategories)
                    .ThenInclude(p => p.Products)
                .Include(p => p.Products)
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category != null)
            {
                products.AddRange(category.Products);

                foreach (var subcategory in category.ChildCategories)
                {
                    products.AddRange(subcategory.Products);

                    foreach (var subsubcategory in subcategory.ChildCategories)
                    {
                        products.AddRange(subsubcategory.Products);
                    }
                }
            }

            return products;
        }

        public async Task<List<Product>> GetFilteredProducts(int categoryId, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var products = await GetProductsByCategory(categoryId);

            var filteredProducts = products.Where(p => !minPrice.HasValue || p.Price >= minPrice.Value)
                                           .Where(p => !maxPrice.HasValue || p.Price <= maxPrice.Value)
                                           .ToList();

            return filteredProducts;
        }

        public async Task<List<Product>> SortByPriceAscending(int categoryId)
        {
            var products = await GetProductsByCategory(categoryId);

            var sortedProducts = products.OrderBy(p => p.Price).ToList();

            return sortedProducts;
        }

        public async Task<List<Product>> SortByPriceDescending(int categoryId)
        {
            var products = await GetProductsByCategory(categoryId);

            var sortedProducts = products.OrderByDescending(p => p.Price).ToList();

            return sortedProducts;
        }

        public async Task<List<Product>?> UpdateProduct(int id, Product request)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is null)
                return null;

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            await _context.SaveChangesAsync();

            return await _context.Products.ToListAsync();
        }

        public async Task<Product> AddReview(Review review, int userId, int productId)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            var updatedProduct = await _context.Products
                .Where(p => p.Id == productId)
                .Include(p => p.Reviews)
                .ThenInclude(u => u.Users)
                .FirstOrDefaultAsync();

            return updatedProduct;
        }

        public async Task<Product?> DeleteReview(int reviewId, int userId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);

            if (review is null || review.UserId != userId)
            {
                return null;
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            var product = await _context.Products
                .Where(p => p.Id == review.ProductId)
                .Include(p => p.Reviews)
                .ThenInclude(u => u.Users)
                .FirstOrDefaultAsync();

            return product;
        }

        public async Task<Product?> DeleteAnyReview(int reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);


            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            var product = await _context.Products
                .Where(p => p.Id == review.ProductId)
                .Include(p => p.Reviews)
                .ThenInclude(u => u.Users)
                .FirstOrDefaultAsync();

            return product;
        }
    }
}
