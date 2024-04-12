using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petstore_vetclinic_api.Models.Categories;
using petstore_vetclinic_api.Services.SubcategoryService;

namespace petstore_vetclinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoryController : ControllerBase
    {
        private readonly ISubcategoryService _SubcategoryService;

        public SubcategoryController(ISubcategoryService SubcategoryService)
        {
            _SubcategoryService = SubcategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subcategory>>> GetAllSubcategorys()
        {
            return await _SubcategoryService.GetAllSubcategory();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subcategory>> GetSingleSubcategory(int id)
        {
            var result = await _SubcategoryService.GetSingleSubcategory(id);
            if (result is null)
                return NotFound("Subcategory not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Subcategory>>> AddSubcategory(Subcategory Subcategory)
        {
            var result = await _SubcategoryService.AddSubcategory(Subcategory);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Subcategory>>> UpdateSubcategory(int id, Subcategory request)
        {
            var result = await _SubcategoryService.UpdateSubcategory(id, request);
            if (result is null)
                return NotFound("Subcategory not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Subcategory>>> DeleteSubcategory(int id)
        {
            var result = await _SubcategoryService.DeteleSubcategory(id);
            if (result is null)
                return NotFound("Subcategory not found.");

            return Ok(result);
        }
    }
}
