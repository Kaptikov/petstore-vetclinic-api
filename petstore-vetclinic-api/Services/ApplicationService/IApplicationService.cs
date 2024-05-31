using petstore_vetclinic_api.Models.Clinic;

namespace petstore_vetclinic_api.Services.ApplicationService
{
    public interface IApplicationService
    {
        Task<List<Application>> GetAllApplication();
        Task<List<Application>> AddApplication(Application application);
    }
}
