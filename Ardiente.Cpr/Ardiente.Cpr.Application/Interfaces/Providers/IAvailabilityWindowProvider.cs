using Ardiente.Cpr.Business;

namespace Ardiente.Cpr.Application.Interfaces.Providers;

public interface IAvailabilityWindowProvider
{
    Task<List<AvailabilityWindow>> GetAvailabilityWindowsAsync(ScheduleDay scheduleDay);
}