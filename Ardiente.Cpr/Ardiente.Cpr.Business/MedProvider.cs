using Ardalis.GuardClauses;

namespace Ardiente.Cpr.Business;

public class MedProvider
{
    public MedProvider(string name)
    {
        Guard.Against.NullOrWhiteSpace(name, nameof(name), "MedProvider name must be specified");
        AvailabilityWindows = new List<AvailabilityWindow>();
        Name = name;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public List<AvailabilityWindow> AvailabilityWindows { get; set; }
}