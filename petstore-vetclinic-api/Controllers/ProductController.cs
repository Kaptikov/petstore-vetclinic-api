using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petstore_vetclinic_api.Models.Products;
using petstore_vetclinic_api.Services.ProductService;

namespace petstore_vetclinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return await _ProductService.GetAllProduct();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetSingleProduct(int id)
        {
            var result = await _ProductService.GetSingleProduct(id);
            if (result is null)
                return NotFound("Product not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product Product)
        {
            var result = await _ProductService.AddProduct(Product);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Product>>> UpdateProduct(int id, Product request)
        {
            var result = await _ProductService.UpdateProduct(id, request);
            if (result is null)
                return NotFound("Product not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var result = await _ProductService.DeteleProduct(id);
            if (result is null)
                return NotFound("Product not found.");

            return Ok(result);
        }
    }
}
