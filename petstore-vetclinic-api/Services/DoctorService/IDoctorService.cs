using petstore_vetclinic_api.Models.Clinic;
using petstore_vetclinic_api.Models.Products;

namespace petstore_vetclinic_api.Services.DoctorService
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetAllDoctors();
    }
}
