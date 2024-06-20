using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petstore_vetclinic_api.Models.Carts;
using petstore_vetclinic_api.Models.Orders;
using petstore_vetclinic_api.Services.CartItemService;
using petstore_vetclinic_api.Services.OrderService;

namespace petstore_vetclinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;

        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Order>>> GetAllOrder()
        {
            return await _OrderService.GetAllOrder();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartItem>> GetSingleOrder(int id)
        {
            var result = await _OrderService.GetSingleOrder(id);
            if (result is null)
                return NotFound("Order not found.");

            return Ok(result);
        }


        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<Order>>> GetOrdersByUserId(int userId)
        {
            var result = await _OrderService.GetOrdersByUserId(userId);
            if (result is null)
                return NotFound("Order not found for the user.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> AddOrder(Order Order)
        {
            var result = await _OrderService.AddOrder(Order);

            return Ok(result);
        }

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Order>>> UpdateOrder(int id, Order request)
        {
            var result = await _OrderService.UpdateOrder(id, request);
            if (result is null)
                return NotFound("CartItem not found.");

            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Order>>> DeleteOrder(int id)
        {
            var result = await _OrderService.DeleteOrder(id);
            if (result is null)
                return NotFound("Order not found.");

            return Ok(result);
        }
    }
}
