namespace Ardiente.Cpr.Business;

public class ScheduleDay
{
    public ScheduleDay(int year, int month, int day)
    {
        Date = new DateOnly(year, month, day);
    }

    public Guid Id { get; set; }
    public DateOnly Date { get; set; }
}