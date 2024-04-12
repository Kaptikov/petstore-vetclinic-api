using petstore_vetclinic_api.Models.Categories;

namespace petstore_vetclinic_api.Services.SubcategoryService
{
    public interface ISubcategoryService
    {
        Task<List<Subcategory>> GetAllSubcategory();
        Task<Subcategory>? GetSingleSubcategory(int id);

        Task<List<Subcategory>> AddSubcategory(Subcategory subcategory);

        Task<List<Subcategory>?> UpdateSubcategory(int id, Subcategory request);

        Task<List<Subcategory>?> DeteleSubcategory(int id);
    }
}
