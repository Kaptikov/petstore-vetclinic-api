using petstore_vetclinic_api.Models.Categories;

namespace petstore_vetclinic_api.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategory();
        Task<Category>? GetSingleCategory(int id);

        Task<List<Category>> AddCategory(Category category);

        Task<List<Category>?> UpdateCategory(int id, Category request);

        Task<List<Category>?> DeteleCategory(int id);
    }
}
