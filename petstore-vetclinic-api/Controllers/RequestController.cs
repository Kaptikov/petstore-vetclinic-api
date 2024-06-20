using Microsoft.AspNetCore.Authorization;
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

        [HttpGet, Authorize(Roles = "Admin")]
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

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Request>>> UpdateRequest(int id, Request request)
        {
            var result = await _requestService.UpdateRequest(id, request);

            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Request>>> DeleteRequest(int id)
        {
            var result = await _requestService.DeleteRequest(id);

            return Ok(result);
        }
    }
}
