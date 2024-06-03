using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Clinic;
using petstore_vetclinic_api.Models.Products;

namespace petstore_vetclinic_api.Services.DoctorService
{
    public class DoctorService : IDoctorService
    {
        private readonly DataContext _context;

        public DoctorService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Doctor>> GetAllDoctors()
        {
            var doctors = await _context.Doctors.Include(d => d.Schedules).ToListAsync();
            return doctors;
        }
    }
}
