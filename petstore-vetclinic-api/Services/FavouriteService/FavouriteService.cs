using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Favourites;

namespace petstore_vetclinic_api.Services.FavouriteService
{
    public class FavouriteService
    {
       /* private readonly DataContext _context;

        public FavouriteService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Favourite>> GetAllFavourite()
        {
            var favourites = await _context.Favourites.ToListAsync();
            return favourites;
        }

        public async Task<Favourite?> GetSingleFavourite(int id)
        {
            var favourite = await _context.Favourites.FindAsync(id);
            if (favourite is null)
                return favourite;

            return favourite;
        }*/
    }
}
