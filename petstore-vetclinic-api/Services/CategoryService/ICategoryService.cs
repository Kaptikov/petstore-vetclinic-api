using petstore_vetclinic_api.Models.Categories;
using petstore_vetclinic_api.Models.Products;

namespace petstore_vetclinic_api.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategory();
        Task<Category>? GetSingleCategory(int id);

        Task<List<Category>> AddCategory(Category category);
        Task<List<Category>?> GetCategory();
        Task<List<Category>?> GetSubcategories(int parentId);
        Task<List<Category>?> GetSubSubcategories(int parentId);
       // Task<List<Category>?> GetAllSubcategories(int parentId);
        Task<List<Category>?> UpdateCategory(int id, Category request);

        Task<List<Category>?> DeteleCategory(int id);
    }
}
