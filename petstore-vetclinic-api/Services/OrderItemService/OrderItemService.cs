using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Carts;
using petstore_vetclinic_api.Models.Orders;

namespace petstore_vetclinic_api.Services.OrderItemService
{
    public class OrderItemService : IOrderItemService
    {
        private readonly DataContext _context;

        public OrderItemService(DataContext context)
        {
            _context = context;
        }

      /* public async Task<OrderItem> AddOrderItem(OrderItem orderItem)
        {
    
        }*/

      /*  public async Task<List<OrderItem>?> DeleteOrderItem(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem is null)
                return null;

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
            return await _context.OrderItems.ToListAsync();
        }

        public async Task<List<Order>> GetAllOrderItem()
        {
            var orderItems = await _context.OrderItems.Include(c => c.OrderItems).ToListAsync();
            return orderItems;
        }*/

       /* public async Task<Order?> GetSingleOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order is null)
                return order;

            return order;
        }*/

       /* public async Task<List<Order>?> UpdateOrderItem(int id, Order request)
        {
            var order = await _context.Orders
                .Include(ci => ci.OrderItems)
                .FirstOrDefaultAsync(ci => ci.Id == id);

            if (order is null)
                return null;

           // order.Quantity = request.Quantity;

            await _context.SaveChangesAsync();

            return await _context.Orders.Include(ci => ci.OrderItems).ToListAsync();
        }*/
    }
}
