using petstore_vetclinic_api.Models.Favourites;

namespace petstore_vetclinic_api.Services.FavouriteItemService
{
    public interface IFavouriteItemService
    {
        Task<List<FavouriteItem>> GetAllFavouriteItem();
        Task<FavouriteItem>? GetSingleFavouriteItem(int id);

        Task<List<FavouriteItem>> AddFavouriteItem(FavouriteItem favouriteItem);

        Task<List<FavouriteItem>?> UpdateFavouriteItem(int id, FavouriteItem request);

        Task<List<FavouriteItem>?> DeteleFavouriteItem(int id);
    }
}
