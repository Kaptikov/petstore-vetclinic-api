using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petstore_vetclinic_api.Models.Animals;
using petstore_vetclinic_api.Models.Clinic;
using petstore_vetclinic_api.Services.Animals;
using petstore_vetclinic_api.Services.DoctorService;

namespace petstore_vetclinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> GetAllDoctors()
        {
            return await _doctorService.GetAllDoctors();
        }
    }
}
