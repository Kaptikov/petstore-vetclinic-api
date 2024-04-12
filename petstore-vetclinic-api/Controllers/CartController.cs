using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petstore_vetclinic_api.Models.Carts;
using petstore_vetclinic_api.Services.CartService;

namespace petstore_vetclinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _CartService;

        public CartController(ICartService CartService)
        {
            _CartService = CartService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cart>>> GetAllCart()
        {
            return await _CartService.GetAllCart();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetSingleCart(int id)
        {
            var result = await _CartService.GetSingleCart(id);
            if (result is null)
                return NotFound("Product not found.");

            return Ok(result);
        }
    }
}
