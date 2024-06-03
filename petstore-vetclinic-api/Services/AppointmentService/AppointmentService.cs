using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Carts;
using petstore_vetclinic_api.Models.Clinic;

namespace petstore_vetclinic_api.Services.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly DataContext _context;

        public AppointmentService(DataContext context)
        {
            _context = context;
        }

       public async Task<List<Appointment>> AddAppointment(Appointment appointment, int userId)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            var schedule = await _context.Schedules
                .Where(s => s.DoctorId == appointment.DoctorId && s.Date == appointment.Date && s.StartTime == appointment.Time)
                .FirstOrDefaultAsync();

            if (schedule != null)
            {
                schedule.IsAvailable = false;
                _context.Update(schedule);
                await _context.SaveChangesAsync();
            }

            var appointments = await _context.Appointments
                .Where(fi => fi.UserId == userId)
                .ToListAsync();

            return appointments;
        }
        
        public async Task<List<Appointment>> GetAllAppointment()
        {
            var appointments = await _context.Appointments.ToListAsync();
            return appointments;
        }

        public async Task<List<Appointment>?> GetAllAppointmentsByUserId(int userId)
        {
            return await _context.Appointments.Where(a => a.UserId == userId).ToListAsync();
        }
    }
}
