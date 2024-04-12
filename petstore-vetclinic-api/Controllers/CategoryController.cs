using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petstore_vetclinic_api.Models.Categories;
using petstore_vetclinic_api.Services.CategoryService;

namespace petstore_vetclinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;

        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategorys()
        {
            return await _CategoryService.GetAllCategory();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetSingleCategory(int id)
        {
            var result = await _CategoryService.GetSingleCategory(id);
            if (result is null)
                return NotFound("Category not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> AddCategory(Category Category)
        {
            var result = await _CategoryService.AddCategory(Category);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Category>>> UpdateCategory(int id, Category request)
        {
            var result = await _CategoryService.UpdateCategory(id, request);
            if (result is null)
                return NotFound("Category not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Category>>> DeleteCategory(int id)
        {
            var result = await _CategoryService.DeteleCategory(id);
            if (result is null)
                return NotFound("Category not found.");

            return Ok(result);
        }
    }
}
