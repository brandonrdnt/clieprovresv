using Ardalis.GuardClauses;

namespace Ardiente.Cpr.Business;

public class AppointmentSlot
{
    public AppointmentSlot(ScheduleDay scheduleDay, AvailabilityWindow availabilityWindow, TimeOnly startTime)
    {
        Guard.Against.Null(scheduleDay);
        Guard.Against.Null(availabilityWindow);
        Guard.Against.Null(startTime);
        
        ScheduleDay = scheduleDay;
        StartTime = startTime;
        MedProvider = availabilityWindow.MedProvider;
    }
    
    public ScheduleDay ScheduleDay { get; set; }
    public TimeOnly StartTime { get; set; }
    public MedProvider MedProvider { get; set; }
    
    public DateTime StartDateTime => new DateTime(ScheduleDay.Date.Year, ScheduleDay.Date.Month, ScheduleDay.Date.Day, StartTime.Hour, StartTime.Minute, 0);
}