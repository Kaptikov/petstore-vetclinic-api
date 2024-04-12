using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Users;

namespace petstore_vetclinic_api.Services.AuthService
{
    public class SignUpService : ISignUpService
    {
        private readonly DataContext _context;

        public SignUpService(DataContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

    }
}
