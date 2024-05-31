using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Animals;

namespace petstore_vetclinic_api.Services.Animals
{
    public class AnimalService : IAnimalService
    {
        private readonly DataContext _context;

        public AnimalService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Animal>> AddAnimal(Animal animal)
        {
           
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();

            Console.WriteLine("Animal added: " + animal.Name);

            return await _context.Animals.ToListAsync();
        }

        public async Task<List<Animal>?> DeteleAnimal(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal is null)
                return null;

            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
            return await _context.Animals.ToListAsync();
        }

        public async Task<List<Animal>> GetAllAnimals()
        {
            var animals = await _context.Animals.ToListAsync(); 
            return animals;
        }

        public async Task<Animal?> GetSingleAnimal(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal is null)
                return animal;

            return animal;
        }

        public async Task<Animal>? UpdateAnimal(int id, Animal request)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal is null)
                return null;

            animal.Name = request.Name;
            animal.Description = request.Description;
            animal.Age = request.Age;
            animal.Breed = request.Breed;
            animal.Gender = request.Gender;
            animal.Type = request.Type;

            await _context.SaveChangesAsync();

            return animal;
        }
        public async Task<List<Animal>> GetAnimalsByUserId(int userId)
        {
            return await _context.Animals.Where(a => a.UserId == userId).ToListAsync();
        }
    }
}
