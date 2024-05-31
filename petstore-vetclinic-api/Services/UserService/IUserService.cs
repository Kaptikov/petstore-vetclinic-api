using petstore_vetclinic_api.Models.Users;

namespace petstore_vetclinic_api.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUser();
        Task<User>? GetSingleUser(int id);

        Task<List<User>> AddUser(User user);

        //Task<List<User>?> UpdateUser(int id, User request);
        Task<User>? UpdateUser(int id, User request);

        Task<List<User>?> DeteleUser(int id);
    }
}
