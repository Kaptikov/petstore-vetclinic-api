using petstore_vetclinic_api.Models.Users;

namespace petstore_vetclinic_api.Services.AuthService
{
    public interface ISignUpService
    {
        Task AddUser(User user);
    }
}
