using petstore_vetclinic_api.Models.Clinic;
using petstore_vetclinic_api.Models.Products;

namespace petstore_vetclinic_api.Services.ScheduleService
{
    public interface IScheduleService
    {
        Task<List<Schedule>> GetAllSchedules();
        Task<List<Schedule>> GetScheduleForDoctor(int doctorId);
        Task<List<DateTime>> GetDateForDoctor(int doctorId);
        Task<List<Schedule>> GetFilteredSchedule(int doctorId, DateTime? date);
        Task<List<TimeSpan>> GetAvailableTimesForDate(int doctorId, DateTime date);
    }
}
