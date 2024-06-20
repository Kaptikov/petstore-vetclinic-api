using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Carts;
using petstore_vetclinic_api.Models.Clinic;
using petstore_vetclinic_api.Models.Users;

namespace petstore_vetclinic_api.Services.RequestService
{
    public class RequestService : IRequestService
    {
        private readonly DataContext _context;

        public RequestService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Request>?> AddRequests(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            var requests = await _context.Requests.ToListAsync();

            return requests;
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

        public async Task<List<Request>> GetAllRequest()
        {
            var requests = await _context.Requests.ToListAsync();
            return requests;
        }

        public async Task<List<Request>?> UpdateRequest(int id, Request request)
        {
            var requests = await _context.Requests.FirstOrDefaultAsync(ci => ci.Id == id);

            if (requests is null)
                return null;

            requests.Status = request.Status;

            await _context.SaveChangesAsync();

            return await _context.Requests.ToListAsync();
        }

        public async Task<List<Request>?> DeleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request is null)
                return null;

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return await _context.Requests.ToListAsync();
        }
    }
}
