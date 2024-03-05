using Ardiente.Cpr.Application.Interfaces;
using Ardiente.Cpr.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ardiente.Cpr.Api.Controllers
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
        // GET
        public IActionResult Index(DateTime date)
        {
            var appointmentSlots = _scheduleService.GetAvailableAppointmentSlots(new ScheduleDay(date.Year, date.Month, date.Day));

            return Ok(appointmentSlots);
        }        
    }
}
