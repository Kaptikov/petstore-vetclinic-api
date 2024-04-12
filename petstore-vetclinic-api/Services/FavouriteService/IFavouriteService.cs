using petstore_vetclinic_api.Models.Favourites;

namespace petstore_vetclinic_api.Services.FavouriteService
{
    public interface IFavouriteService
    {
        Task<List<Favourite>> GetAllFavourite();
        Task<Favourite>? GetSingleFavourite(int id);
    }
}
