using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petstore_vetclinic_api.Models.Clinic;
using petstore_vetclinic_api.Services.AppointmentService;

namespace petstore_vetclinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Appointment>>> GetAllAppointment()
        {
            return await _appointmentService.GetAllAppointment();
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<Appointment>>> GetAllAppointmentsByUserId(int userId)
        {
            return await _appointmentService.GetAllAppointmentsByUserId(userId);
        }

        [HttpPost("user/{userId}")]
        public async Task<ActionResult<List<Appointment>>> AddAppointment(Appointment appointment, int userId)
        {
            return await _appointmentService.AddAppointment(appointment, userId);
        }
    }
}
