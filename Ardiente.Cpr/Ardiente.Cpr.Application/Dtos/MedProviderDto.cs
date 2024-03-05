using Ardiente.Cpr.Business;

namespace Ardiente.Cpr.Application.Dtos;

public class MedProviderDto
{
    public string Name { get; set; }
    public Guid Id { get; set; }
    
    public static MedProviderDto FromMedProvider(MedProvider medProvider)
    {
        return new MedProviderDto
        {
            Id = medProvider.Id,
            Name = medProvider.Name
        };
    }
    
    public static MedProvider ToMedProvider(MedProviderDto medProviderDto)
    {
        return new MedProvider(medProviderDto.Name)
        {
            Id = medProviderDto.Id
        };
    }
}

