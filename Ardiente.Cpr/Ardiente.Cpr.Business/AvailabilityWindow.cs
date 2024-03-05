using Ardalis.GuardClauses;

namespace Ardiente.Cpr.Business;

public class AvailabilityWindow
{
    public AvailabilityWindow(MedProvider medProvider, ScheduleDay scheduleDay, int availabilityStartHour, int availabilityStartMinute, int availabilityEndHour, int availabilityEndMinute)
    {
        Guard.Against.Null(medProvider, nameof(medProvider), "MedProvider must be specified");
        Guard.Against.Null(scheduleDay, nameof(scheduleDay), "ScheduleDay must be specified");
        Guard.Against.InvalidInput(availabilityStartMinute, nameof(availabilityStartMinute), i => i % 15 == 0, 
             "Availability start minute must be a multiple of 15");
        Guard.Against.InvalidInput(availabilityEndMinute, nameof(availabilityEndMinute), i => i % 15 == 0, 
            "Availability end minute must be a multiple of 15");
        
        ScheduleDayId = scheduleDay.Id;
        AvailabilityStartTime = new TimeOnly(availabilityStartHour, availabilityStartMinute);
        AvailabilityEndTime = new TimeOnly(availabilityEndHour, availabilityEndMinute);
        MedProvider = medProvider;
    }

    public Guid Id { get; set; }
    public Guid ScheduleDayId { get; set; }
    public TimeOnly AvailabilityStartTime { get; set; }
    public TimeOnly AvailabilityEndTime { get; set; }
    public MedProvider MedProvider { get; set; }

    public bool Contains(TimeOnly time)
    {
        return time.IsBetween(AvailabilityStartTime, AvailabilityEndTime);
    }
}