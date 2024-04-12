using petstore_vetclinic_api.Models.Carts;

namespace petstore_vetclinic_api.Services.CartService
{
    public interface ICartService
    {
        Task<List<Cart>> GetAllCart();
        Task<Cart>? GetSingleCart(int id);
    }
}
