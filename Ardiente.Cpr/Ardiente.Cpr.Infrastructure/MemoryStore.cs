using Ardiente.Cpr.Business;

namespace Ardiente.Cpr.Infrastructure;

public class MemoryStore : IMemoryStore
{
    public MemoryStore()
    {
        MedProviders = new Dictionary<Guid, MedProvider>();
    }
    public Dictionary<Guid, MedProvider> MedProviders { get; set; }
    public MemoryStore GetMemoryStore()
    {
        return this;
    }
}