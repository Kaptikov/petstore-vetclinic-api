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

        [HttpGet("search")]
        public async Task<ActionResult<List<Product>>> SearchProductsByName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return NotFound("Product not found.");
            }

            var result = await _ProductService.SearchProductsByName(name);
            if (result is null)
            {
                return NotFound("Product not found.");
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetSingleProduct(int id)
        {
            var results = await _ProductService.GetSingleProduct(id);
            if (results is null)
                return NotFound("Product not found.");

            return Ok(results);
        }

      /*  [HttpGet("categories/{categoryId}")]
        public async Task<ActionResult<List<Product>>> GetProductsInSubSubcategories(int categoryId)
        {
            var products = await _ProductService.GetProductsInSubSubcategories(categoryId);
            if (products == null)
            {
                return NotFound("No products found in subsubcategories for the provided category ID.");
            }

            return Ok(products);
        }

        [HttpGet("subcategories/{categoryId}")]
        public async Task<ActionResult<List<Product>>> GetProductsInSubSubcategoriesBySubCategory(int categoryId)
        {
            var products = await _ProductService.GetProductsInSubSubcategoriesBySubCategory(categoryId);
            if (products == null)
            {
                return NotFound("No products found in subsubcategories for the provided category ID.");
            }

            return Ok(products);
        }

        [HttpGet("subsubcategories/{categoryId}")]
        public async Task<ActionResult<List<Product>>> GetProductsInSubSubcategoriesBySubSubCategory(int categoryId)
        {
            var products = await _ProductService.GetProductsInSubSubcategoriesBySubSubCategory(categoryId);
            if (products == null)
            {
                return NotFound("No products found in subsubcategories for the provided category ID.");
            }

            return Ok(products);
        }
        */

        [HttpGet("Category/{categoryId}")]
        public async Task<ActionResult<List<Product>>> GetProductsByCategory(int categoryId)
        {
            var products = await _ProductService.GetProductsByCategory(categoryId);
            if (products == null)
            {
                return NotFound("No products found in subsubcategories for the provided category ID.");
            }

            return Ok(products);
        }

        [HttpGet("Category/{categoryId}/filter")]
        public async Task<IActionResult> GetFilteredProducts(int categoryId, [FromQuery] decimal? minPrice = null, [FromQuery] decimal? maxPrice = null)
        {
            var filteredProducts = await _ProductService.GetFilteredProducts(categoryId, minPrice, maxPrice);
            if (filteredProducts == null)
            {
                return NotFound("No products found");
            }

            return Ok(filteredProducts);
        }

        [HttpGet("Category/{categoryId}/sort/ascending")]
        public async Task<IActionResult> SortByPriceAscending(int categoryId)
        {
            var sortedProducts = await _ProductService.SortByPriceAscending(categoryId);
            if (sortedProducts == null)
            {
                return NotFound("No products found");
            }

            return Ok(sortedProducts);
        }


        [HttpGet("Category/{categoryId}/sort/descending")]
        public async Task<IActionResult> SortByPriceDescending(int categoryId)
        {
            var sortedProducts = await _ProductService.SortByPriceDescending(categoryId);
            if (sortedProducts == null)
            {
                return NotFound("No products found");
            }

            return Ok(sortedProducts);
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
