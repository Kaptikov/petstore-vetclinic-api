using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Carts;
using petstore_vetclinic_api.Models.Orders;

namespace petstore_vetclinic_api.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }

        public async Task<Order> AddOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var cartItems = await _context.CartItems.Where(ci => ci.UserId == order.UserId).ToListAsync();

            var orderItems = cartItems.Select(ci => new OrderItem
            {
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,
                OrderId = order.Id
            });

            _context.OrderItems.AddRange(orderItems);
            await _context.SaveChangesAsync();

            return await _context.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == order.Id);
        }

        public async Task<List<Order>?> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order is null)
                return null;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return await _context.Orders.ToListAsync();
        }

        public async Task<List<Order>> GetAllOrder()
        {
            var orders = await _context.Orders.Include(c => c.OrderItems).ToListAsync();
            return orders;
        }

        public async Task<Order?> GetSingleOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order is null)
                return order;

            return order;
        }

        public async Task<List<Order>?> GetOrdersByUserId(int userId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(a => a.UserId == userId).ToListAsync();
        }

        public async Task<List<Order>?> UpdateOrder(int id, Order request)
        {
            var order = await _context.Orders
                .Include(oi => oi.OrderItems)
                .FirstOrDefaultAsync(ci => ci.Id == id);

            if (order is null)
                return null;

           // order.Quantity = request.Quantity;

            await _context.SaveChangesAsync();

            return await _context.Orders.Include(ci => ci.OrderItems).ToListAsync();
        }
    }
}
