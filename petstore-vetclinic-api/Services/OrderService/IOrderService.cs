using petstore_vetclinic_api.Models.Orders;

namespace petstore_vetclinic_api.Services.OrderService
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrder();
        Task<Order>? GetSingleOrder(int id);
        Task<List<Order>?> GetOrdersByUserId(int userId);
        Task<Order> AddOrder(Order order);

        Task<List<Order>?> UpdateOrder(int id, Order request);

        Task<List<Order>?> DeleteOrder(int id);
    }
}
