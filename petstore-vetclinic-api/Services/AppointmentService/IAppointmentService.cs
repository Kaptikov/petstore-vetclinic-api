using petstore_vetclinic_api.Models.Clinic;

namespace petstore_vetclinic_api.Services.AppointmentService
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> AddAppointment(Appointment appointment, int userId);
        Task<List<Appointment>> GetAllAppointment();
        Task<List<Appointment>> GetAllAppointmentsByUserId(int userId);
    }
}
