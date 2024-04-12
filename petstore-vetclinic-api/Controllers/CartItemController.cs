using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<ActionResult<List<CartItem>>> AddCartItem(CartItem CartItem)
        {
            var result = await _CartItemService.AddCartItem(CartItem);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<CartItem>>> UpdateCartItem(int id, CartItem request)
        {
            var result = await _CartItemService.UpdateCartItem(id, request);
            if (result is null)
                return NotFound("CartItem not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CartItem>>> DeleteCartItem(int id)
        {
            var result = await _CartItemService.DeteleCartItem(id);
            if (result is null)
                return NotFound("CartItem not found.");

            return Ok(result);
        }
    }
}
