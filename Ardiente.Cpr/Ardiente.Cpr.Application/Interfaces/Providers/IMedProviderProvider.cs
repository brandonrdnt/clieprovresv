using Ardiente.Cpr.Application.Dtos;
using Ardiente.Cpr.Business;

namespace Ardiente.Cpr.Application.Interfaces.Providers;

public interface IMedProviderProvider
{
    List<MedProviderDto> GetMedProviders();
}