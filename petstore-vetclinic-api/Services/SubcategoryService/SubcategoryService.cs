using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Categories;

namespace petstore_vetclinic_api.Services.SubcategoryService
{
    public class SubcategoryService
    {
       /* private readonly DataContext _context;

        public SubcategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Subcategory>> AddSubcategory(Subcategory subcategory)
        {
            _context.Subcategories.Add(subcategory);
            await _context.SaveChangesAsync();

            return await _context.Subcategories.ToListAsync();
        }

        public async Task<List<Subcategory>?> DeteleSubcategory(int id)
        {
            var subcategory = await _context.Subcategories.FindAsync(id);
            if (subcategory is null)
                return null;

            _context.Subcategories.Remove(subcategory);
            await _context.SaveChangesAsync();
            return await _context.Subcategories.ToListAsync();
        }

        public async Task<List<Subcategory>> GetAllSubcategory()
        {
            var subcategories = await _context.Subcategories.ToListAsync();
            return subcategories;
        }

        public async Task<Subcategory?> GetSingleSubcategory(int id)
        {
            var subcategory = await _context.Subcategories.FindAsync(id);
            if (subcategory is null)
                return subcategory;

            return subcategory;
        }

        public async Task<List<Subcategory>?> UpdateSubcategory(int id, Subcategory request)
        {
            var subcategory = await _context.Subcategories.FindAsync(id);
            if (subcategory is null)
                return null;

            subcategory.Name = request.Name;


            await _context.SaveChangesAsync();

            return await _context.Subcategories.ToListAsync();
        }*/
    }
}
