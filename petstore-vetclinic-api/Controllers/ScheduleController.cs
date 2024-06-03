using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petstore_vetclinic_api.Models.Animals;
using petstore_vetclinic_api.Models.Clinic;
using petstore_vetclinic_api.Services.Animals;
using petstore_vetclinic_api.Services.ScheduleService;

namespace petstore_vetclinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Schedule>>> GetAllSchedules()
        {
            return await _scheduleService.GetAllSchedules();
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<ActionResult<List<Schedule>>> GetScheduleForDoctor(int doctorId)
        {
            return await _scheduleService.GetScheduleForDoctor(doctorId);
        }


        [HttpGet("date/doctor/{doctorId}")]
        public async Task<ActionResult<List<DateTime>>> GetDateForDoctor(int doctorId)
        {
            return await _scheduleService.GetDateForDoctor(doctorId);
        }

        [HttpGet("doctor/{doctorId}/date/{date}")]
        public async Task<ActionResult<List<Schedule>>> GetFilteredSchedule(int doctorId, DateTime? date)
        {
            return await _scheduleService.GetFilteredSchedule(doctorId, date);
        }

        [HttpGet("time/doctor/{doctorId}/date/{date}")]
        public async Task<ActionResult<List<TimeSpan>>> GetAvailableTimesForDate(int doctorId, DateTime date)
        {
            return await _scheduleService.GetAvailableTimesForDate(doctorId, date);
        }
    }
}
