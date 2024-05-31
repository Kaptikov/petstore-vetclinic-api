using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petstore_vetclinic_api.Models.Clinic;
using petstore_vetclinic_api.Services.ApplicationService;

namespace petstore_vetclinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Application>>> GetAllApplication()
        {
            return await _applicationService.GetAllApplication();
        }

        [HttpPost]
        public async Task<ActionResult<List<Application>>> AddApplication(Application application)
        {
            var result = await _applicationService.AddApplication(application);

            return Ok(result);
        }
    }
}
