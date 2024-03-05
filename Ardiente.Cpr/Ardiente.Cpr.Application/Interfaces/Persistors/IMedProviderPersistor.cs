using Ardiente.Cpr.Application.Dtos;

namespace Ardiente.Cpr.Application.Interfaces.Persistors;

public interface IMedProviderPersistor
{
    void SaveMedProvider(MedProviderDto medProvider);
}