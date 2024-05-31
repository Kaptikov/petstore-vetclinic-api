using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Categories;
using petstore_vetclinic_api.Models.Products;

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

        public async Task<List<Category>?> GetCategory()
        {
            var category = await _context.Categories.Include(c => c.ChildCategories).Where(c => c.ParentCategoryId == null).ToListAsync();
            return category;
        }

        public async Task<List<Category>?> GetSubcategories(int parentId)
        {
            var subcategories = await _context.Categories
                .Include(c => c.ChildCategories)
                .Where(c => c.ParentCategoryId == parentId)
                .ToListAsync();
            return subcategories;
        }
        public async Task<List<Category>?> GetSubSubcategories(int parentId)
        {
            var subsubcategories = await _context.Categories
                .Where(c => c.ParentCategoryId == parentId && c.ChildCategories.Any())
                .SelectMany(c => c.ChildCategories)
                .Include(c => c.ParentCategory)
                .ToListAsync();
            return subsubcategories;
        }

     /*   public async Task<List<Category>> GetAllSubcategories(int parentId)
        {
            var subcategories = await _context.Categories
                .Where(c => c.ParentCategoryId == parentId)
                .ToListAsync();

            var allSubcategories = new List<Category>();
            foreach (var subcategory in subcategories)
            {
                allSubcategories.AddRange(await GetAllSubcategories(subcategory.Id));

                foreach (var subsubcategory in subcategories)
                {
                    allSubcategories.AddRange(await GetAllSubcategories(subsubcategory.Id));
                }
            }

            return allSubcategories;
        }*/

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

