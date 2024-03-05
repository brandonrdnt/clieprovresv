using Ardiente.Cpr.Business;

namespace Ardiente.Cpr.Application.Interfaces;

public interface IScheduleService
{
    Task<List<AppointmentSlot>> GetAvailableAppointmentSlots(ScheduleDay scheduleDay);
}