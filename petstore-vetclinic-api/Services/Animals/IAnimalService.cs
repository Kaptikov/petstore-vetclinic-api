using petstore_vetclinic_api.Models.Animals;

namespace petstore_vetclinic_api.Services.Animals
{
    public interface IAnimalService
    {
        Task<List<Animal>> GetAllAnimals();
        Task<Animal>? GetSingleAnimal(int id);
        Task<List<Animal>> AddAnimal(Animal animal, int userId);
        Task<Animal>? UpdateAnimal(int id, Animal request);
        Task<List<Animal>?> DeteleAnimal(int id, int userId);
        Task<List<Animal>?> GetAnimalsByUserId(int userId);
    }
}
