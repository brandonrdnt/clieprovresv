using Ardiente.Cpr.Application.Dtos;
using Ardiente.Cpr.Application.Interfaces.Persistors;

namespace Ardiente.Cpr.Infrastructure.Persistors;

public class MedProviderPersistor: IMedProviderPersistor
{
    private readonly IMemoryStore _memoryStore;
    public MedProviderPersistor(IMemoryStore memoryStore)
    {
        _memoryStore = memoryStore;
    }
    public void SaveMedProvider(MedProviderDto medProvider)
    {
        var medProviderEntity = MedProviderDto.ToMedProvider(medProvider);
        medProviderEntity.Id = Guid.NewGuid();
        _memoryStore.GetMemoryStore().MedProviders.Add(medProviderEntity.Id, medProviderEntity);   
    }
}