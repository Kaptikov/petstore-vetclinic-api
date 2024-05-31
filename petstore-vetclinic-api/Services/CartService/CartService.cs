using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Animals;
using petstore_vetclinic_api.Models.Carts;

namespace petstore_vetclinic_api.Services.CartService
{
   /* public class CartService : ICartService
    {
        private readonly DataContext _context;

        public CartService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Cart>> GetAllCart()
        {
            var carts = await _context.Carts.ToListAsync();
            return carts;
        }

        public async Task<Cart?> GetSingleCart(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart is null)
                return cart;

            return cart;
        }

        public async Task<List<Cart>?> GetCartsByUserId(int userId)
        {
            return await _context.Carts
                .Include(c => c.CartItems)
                .Where(a => a.UserId == userId)
                .ToListAsync();
        }
    }
   */
}
