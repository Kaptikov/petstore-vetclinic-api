using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Animals;
using petstore_vetclinic_api.Models.Carts;

namespace petstore_vetclinic_api.Services.CartItemService
{
    public class CartItemService : ICartItemService
    {
        private readonly DataContext _context;

        public CartItemService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<CartItem>> AddCartItem(CartItem cartItem, int userId)
        {
            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();

            var cartItemsWithProducts = await _context.CartItems
                .Include(ci => ci.Products)
                .Where(fi => fi.UserId == userId)
                .ToListAsync();

            return cartItemsWithProducts;

            //return await _context.CartItems.ToListAsync();
        }

        public async Task<List<CartItem>?> DeleteCartItem(int id, int userId)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem is null)
                return null;

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            var updatedCartItems = _context.CartItems
             .Where(fi => fi.UserId == userId)
             .ToList();
            //return await _context.CartItems.ToListAsync();
            return updatedCartItems;
        }

        public async Task<List<CartItem>> GetAllCartItem()
        {
            var cartItems = await _context.CartItems.Include(c => c.Products).ToListAsync();
            return cartItems;
        }

        public async Task<CartItem?> GetSingleCartItem(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem is null)
                return cartItem;

            return cartItem;
        }

        public async Task<List<CartItem>?> GetCartItemsByUserId(int userId)
        {
            return await _context.CartItems.Include(p => p.Products).Where(a => a.UserId == userId).ToListAsync();
        }

        public async Task<List<CartItem>?> UpdateCartItem(int id, CartItem request, int userId)
        {
            var cartItem = await _context.CartItems
                .Include(ci => ci.Products)
                .FirstOrDefaultAsync(ci => ci.Id == id);

            if (cartItem is null)
                return null;

            cartItem.Quantity = request.Quantity;

            await _context.SaveChangesAsync();

            return await _context.CartItems.Include(ci => ci.Products).Where(ci => ci.UserId == userId).ToListAsync();
        }
    }
}
