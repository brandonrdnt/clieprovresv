using Ardiente.Cpr.Application.Interfaces.Providers;
using Ardiente.Cpr.Business;

namespace Ardiente.Cpr.Application;

public class ScheduleService
{
    private readonly IAvailabilityWindowProvider _availabilityWindowProvider;

    public ScheduleService(IAvailabilityWindowProvider availabilityWindowProvider)
    {
        _availabilityWindowProvider = availabilityWindowProvider;
    }
    
    public async Task<List<AppointmentSlot>> GetAvailableAppointmentSlots(ScheduleDay scheduleDay)
    {
        var results = new List<AppointmentSlot>();
        var availabilityWindows = await _availabilityWindowProvider.GetAvailabilityWindowsAsync(scheduleDay);
        if (availabilityWindows == null || !availabilityWindows.Any())
            return results;

        var earliestTime = availabilityWindows.Min(x => x.AvailabilityStartTime);
        var latestTime = availabilityWindows.Max(x => x.AvailabilityEndTime);
        
        var currentTime = earliestTime;
        while (currentTime < latestTime)
        {
            var availableWindows = availabilityWindows.Where(aw => aw.Contains(currentTime))?.ToList();
            if (availableWindows != null && availableWindows.Any())
            {
                var availableSlots = availableWindows.Select(aw => new AppointmentSlot(scheduleDay, aw, currentTime)).ToList();
                results.AddRange(availableSlots);
            }
            currentTime = currentTime.AddMinutes(15);
        }
        
        return results;
    }
    
    public async Task MakeReservation(AppointmentSlot slot, DateTime requestedOn)
    {
        var reservation = new Reservation(slot, requestedOn);
        // save reservation to database
    }
}