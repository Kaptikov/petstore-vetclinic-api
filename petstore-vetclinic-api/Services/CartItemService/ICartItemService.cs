using petstore_vetclinic_api.Models.Carts;

namespace petstore_vetclinic_api.Services.CartItemService
{
    public interface ICartItemService
    {
        Task<List<CartItem>> GetAllCartItem();
        Task<CartItem>? GetSingleCartItem(int id);
        Task<List<CartItem>?> GetCartItemsByUserId(int userId);
        Task<List<CartItem>> AddCartItem(CartItem cartItem, int userId);

        Task<List<CartItem>?> UpdateCartItem(int id, CartItem request, int userId);

        Task<List<CartItem>?> DeleteCartItem(int id, int userId);
    }
}
