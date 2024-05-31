using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Carts;
using petstore_vetclinic_api.Models.Clinic;

namespace petstore_vetclinic_api.Services.ApplicationService
{
    public class ApplicationService : IApplicationService
    {
        private readonly DataContext _context;

        public ApplicationService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Application>> AddApplication(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

            var applications = await _context.Applications.ToListAsync();

            return applications;
        }

       /* public async Task<List<Application>?> DeleteApplication(int id, int userId)
        {
            var cartItem = await _context.Applications.FindAsync(id);
            if (cartItem is null)
                return null;

            _context.Applications.Remove(cartItem);
            await _context.SaveChangesAsync();
            var updatedApplications = _context.Applications
             .Where(fi => fi.UserId == userId)
             .ToList();
            //return await _context.CartItems.ToListAsync();
            return updatedApplications;
        }*/

        public async Task<List<Application>> GetAllApplication()
        {
            var applications = await _context.Applications.ToListAsync();
            return applications;
        }

      /*  public async Task<Application?> GetSingleCartItem(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem is null)
                return cartItem;

            return cartItem;
        }*/
    }
}
