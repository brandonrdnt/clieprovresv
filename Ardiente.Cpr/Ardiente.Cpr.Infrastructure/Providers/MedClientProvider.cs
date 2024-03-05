using Ardiente.Cpr.Application.Interfaces.Providers;

namespace Ardiente.Cpr.Infrastructure.Providers;

public class MedClientProvider : IMedClientProvider
{
    private readonly IMemoryStore _memoryStore;
    public MedClientProvider(IMemoryStore memoryStore)
    {
        _memoryStore = memoryStore;
    }
}