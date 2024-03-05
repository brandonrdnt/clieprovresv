using Ardiente.Cpr.Application.Dtos;
using Ardiente.Cpr.Application.Interfaces.Providers;
using Ardiente.Cpr.Business;

namespace Ardiente.Cpr.Infrastructure.Providers;

public class MedProviderProvider : IMedProviderProvider
{
    private readonly IMemoryStore _memoryStore;
    public MedProviderProvider(IMemoryStore memoryStore)
    {
        _memoryStore = memoryStore;
    }
    public List<MedProviderDto> GetMedProviders()
    {
        return _memoryStore.GetMemoryStore().MedProviders.Values.ToList()
            .Select(MedProviderDto.FromMedProvider).ToList();
    }
}