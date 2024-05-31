using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Carts;
using petstore_vetclinic_api.Models.Favourites;

namespace petstore_vetclinic_api.Services.FavouriteItemService
{
    public class FavouriteItemService : IFavouriteItemService
    {
        private readonly DataContext _context;

        public FavouriteItemService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<FavouriteItem>> AddFavouriteItem(FavouriteItem favouriteItem, int userId)
        {
            _context.FavouriteItems.Add(favouriteItem);
            await _context.SaveChangesAsync();

            var favouriteItemsWithProducts = await _context.FavouriteItems
                .Include(fi => fi.Products)
                .Where(fi => fi.UserId == userId)
                .ToListAsync();

            return favouriteItemsWithProducts;

            //favouriteItem.Products = await _context.Products.FindAsync(favouriteItem.ProductId);

            //return await _context.FavouriteItems.Include(c => c.Products).ToListAsync();
        }

        public async Task<List<FavouriteItem>?> DeteleFavouriteItem(int id, int userId)
        {
            var favouriteItem = await _context.FavouriteItems.FindAsync(id);
            if (favouriteItem is null)
                return null;

            _context.FavouriteItems.Remove(favouriteItem);
            await _context.SaveChangesAsync();

            var updatedFavouriteItems = _context.FavouriteItems
            .Where(fi => fi.UserId == userId)
            .ToList();

            // return await _context.FavouriteItems.ToListAsync();
            return updatedFavouriteItems;
        }

        public async Task<List<FavouriteItem>> GetAllFavouriteItem()
        {
            var favouriteItems = await _context.FavouriteItems.Include(c => c.Products).ToListAsync();
            return favouriteItems;
        }

        public async Task<FavouriteItem?> GetSingleFavouriteItem(int id)
        {
            var favouriteItem = await _context.FavouriteItems.FindAsync(id);
            if (favouriteItem is null)
                return favouriteItem;

            return favouriteItem;
        }

        public async Task<List<FavouriteItem>?> GetFavouriteItemsByUserId(int userId)
        {
            return await _context.FavouriteItems.Include(p => p.Products).Where(a => a.UserId == userId).ToListAsync();
        }

        public async Task<List<FavouriteItem>?> UpdateFavouriteItem(int id, FavouriteItem request)
        {
            var favouriteItem = await _context.FavouriteItems.FindAsync(id);
            if (favouriteItem is null)
                return null;

            //favouriteItem.Name = request.Name;
            //favouriteItem.Email = request.Email;
            //favouriteItem.PhoneNumber = request.PhoneNumber;

            await _context.SaveChangesAsync();

            return await _context.FavouriteItems.ToListAsync();
        }
    }
}
