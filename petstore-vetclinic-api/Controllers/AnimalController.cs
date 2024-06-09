using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Models.Animals;
using petstore_vetclinic_api.Services.Animals;

namespace petstore_vetclinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Animal>>> GetAllAnimals()
        {
            return await _animalService.GetAllAnimals();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetSingleAnimal(int id)
        {
            var result = await _animalService.GetSingleAnimal(id);
            if (result is null)
                return NotFound("Animal not found.");

            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<Animal>>> GetAnimalsByUserId(int userId)
        {
            var result = await _animalService.GetAnimalsByUserId(userId);
            if (result is null || result.Count == 0)
                return NotFound("No animals found for the user.");

            return Ok(result);
        }

        [HttpPost("user/{userId}")]
        public async Task<ActionResult<List<Animal>>> AddAnimal(Animal animal, int userId)
        {
            var result = await _animalService.AddAnimal(animal, userId);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Animal>>> UpdateAnimal(int id, Animal request)
        {
            var result = await _animalService.UpdateAnimal(id, request);
            if (result is null)
                return NotFound("Animal not found.");

            return Ok(result);
        }

        [HttpDelete("animal/{id}/user/{userId}")]
        public async Task<ActionResult<List<Animal>>> DeleteAnimal(int id, int userId)
        {
            var result = await _animalService.DeteleAnimal(id, userId);
            if (result is null)
                return NotFound("Animal not found.");

            return Ok(result);
        }

    }

}
