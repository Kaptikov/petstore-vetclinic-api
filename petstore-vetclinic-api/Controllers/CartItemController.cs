using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petstore_vetclinic_api.Models.Animals;
using petstore_vetclinic_api.Models.Carts;
using petstore_vetclinic_api.Services.CartItemService;

namespace petstore_vetclinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _CartItemService;

        public CartItemController(ICartItemService CartItemService)
        {
            _CartItemService = CartItemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CartItem>>> GetAllCartItem()
        {
            return await _CartItemService.GetAllCartItem();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartItem>> GetSingleCartItem(int id)
        {
            var result = await _CartItemService.GetSingleCartItem(id);
            if (result is null)
                return NotFound("Product not found.");

            return Ok(result);
        }


        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<CartItem>>> GetCartItemsByUserId(int userId)
        {
            var result = await _CartItemService.GetCartItemsByUserId(userId);
            if (result is null)
                return NotFound("CartItems not found for the user.");

            return Ok(result);
        }

        [HttpPost("user/{userId}")]
        public async Task<ActionResult<List<CartItem>>> AddCartItem(CartItem CartItem, int userId)
        {
            var result = await _CartItemService.AddCartItem(CartItem, userId);

            return Ok(result);
        }

        [HttpPut("{id}/user/{userId}")]
        public async Task<ActionResult<List<CartItem>>> UpdateCartItem(int id, CartItem request, int userId)
        {
            var result = await _CartItemService.UpdateCartItem(id, request, userId);
            if (result is null)
                return NotFound("CartItem not found.");

            return Ok(result);
        }

        [HttpDelete("{id}/user/{userId}")]
        public async Task<ActionResult<List<CartItem>>> DeleteCartItem(int id, int userId)
        {
            var result = await _CartItemService.DeleteCartItem(id, userId);
            if (result is null)
                return NotFound("CartItem not found.");

            return Ok(result);
        }
    }
}
