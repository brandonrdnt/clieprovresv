using Ardalis.GuardClauses;

namespace Ardiente.Cpr.Business;

public class Reservation
{
    private readonly AppointmentSlot _slot;
    
    public Reservation(AppointmentSlot slot, DateTime requestedOn)
    {
        Guard.Against.Null(slot, nameof(slot), "Appointment slot must be specified");
        Guard.Against.InvalidInput(requestedOn, nameof(requestedOn), i =>
                (slot.StartDateTime - requestedOn).TotalHours >= 24,
            "Reservation must be requested at least 24 hours in advance");

        RequestedOn = requestedOn;
        _slot = slot;
    }
    
    public Guid Id { get; set; }
    public DateTime ConfirmedOn { get; set; }
    public DateTime RequestedOn { get; set; }

    public bool IsExpired()
    {
        if (ConfirmedOn == DateTime.MinValue)
            return (DateTime.Now > RequestedOn.AddMinutes(30));
        else
            return false;
    }
}