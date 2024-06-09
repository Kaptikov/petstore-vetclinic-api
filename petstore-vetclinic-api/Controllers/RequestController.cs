using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petstore_vetclinic_api.Models.Clinic;
using petstore_vetclinic_api.Services.RequestService;

namespace petstore_vetclinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Request>>> GetAllRequest()
        {
            return await _requestService.GetAllRequest();
        }

        [HttpPost]
        public async Task<ActionResult<List<Request>>> AddRequests(Request request)
        {
            var result = await _requestService.AddRequests(request);

            return Ok(result);
        }
    }
}
