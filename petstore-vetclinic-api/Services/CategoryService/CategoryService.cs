using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Categories;

namespace petstore_vetclinic_api.Services.CategoryService
{

    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Category>?> DeteleCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category is null)
                return null;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Category>> GetAllCategory()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category?> GetSingleCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category is null)
                return category;

            return category;
        }

        public async Task<List<Category>?> UpdateCategory(int id, Category request)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category is null)
                return null;

            category.Name = request.Name;


            await _context.SaveChangesAsync();

            return await _context.Categories.ToListAsync();
        }
    }
}

