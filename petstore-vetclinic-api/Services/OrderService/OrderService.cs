using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Carts;
using petstore_vetclinic_api.Models.Orders;

namespace petstore_vetclinic_api.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly Random _random = new Random();
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

            int orderId = order.Id;

            order.OrderNumber = orderId.ToString();

            _context.OrderItems.AddRange(orderItems);
            await _context.SaveChangesAsync();

            return await _context.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == order.Id);
        }

        private string GenerateRandomOrderNumber()
        {
            // Генерация случайного числа от 1000 до 9999
            int randomNumber = _random.Next(1000, 10000);

            // Преобразование числа в строку с ведущими нулями
            string orderNumber = randomNumber.ToString("D4");

            return orderNumber;
        }

        public async Task<List<Order>?> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order is null)
                return null;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return await _context.Orders.Include(c => c.User).Include(c => c.OrderItems).ToListAsync();
        }

        public async Task<List<Order>> GetAllOrder()
        {
            var orders = await _context.Orders.Include(c => c.User).Include(c => c.OrderItems).ThenInclude(oi => oi.Product).ToListAsync();
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
            order.Status = request.Status;
            // order.Quantity = request.Quantity;

            await _context.SaveChangesAsync();

            return await _context.Orders.Include(c => c.User).Include(ci => ci.OrderItems).ThenInclude(oi => oi.Product).ToListAsync();
        }
    }
}
