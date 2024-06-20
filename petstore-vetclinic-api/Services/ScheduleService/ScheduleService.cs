using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Models.Carts;
using petstore_vetclinic_api.Models.Clinic;
using petstore_vetclinic_api.Models.Products;

namespace petstore_vetclinic_api.Services.ScheduleService
{
    public class ScheduleService : IScheduleService
    {
        private readonly DataContext _context;

        public ScheduleService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Schedule>> GetAllSchedules()
        {
            var shedules = await _context.Schedules.ToListAsync();
            return shedules;
        }

        public async Task<List<Schedule>> GetScheduleForDoctor(int doctorId)
        {
            var schedules = await _context.Schedules
               .Where(s => s.DoctorId == doctorId)
               .ToListAsync();

            return schedules.ToList();
        }

        public async Task<List<Schedule>> GetFilteredSchedule(int doctorId, DateTime? date)
        {
            var schedules = await GetScheduleForDoctor(doctorId);

            var filteredSchedules = schedules
                .Where(s => s.DoctorId == doctorId && s.Date == date && s.IsAvailable)
                .ToList();

            return filteredSchedules;
        }

        public async Task<List<DateTime>> GetDateForDoctor(int doctorId)
        {
            var schedules = await _context.Schedules
                .Where(s => s.DoctorId == doctorId)
                .Select(s => s.Date)
                .Distinct()
                .ToListAsync();

            return schedules;
        }

        public async Task<List<TimeSpan>> GetAvailableTimesForDate(int doctorId, DateTime date)
        {
            var availableTimes = await _context.Schedules
                .Where(s => s.DoctorId == doctorId && s.Date == date && s.IsAvailable)
                .Select(s => s.StartTime)
                .ToListAsync();

            return availableTimes;
        }
    }
}
