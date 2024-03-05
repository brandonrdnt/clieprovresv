using Ardiente.Cpr.Application.Interfaces.Persistors;
using Ardiente.Cpr.Application.Interfaces.Providers;
using Microsoft.AspNetCore.Mvc;

namespace Ardiente.Cpr.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class MedClientController : ControllerBase
{
    // GET
    private readonly IMedClientProvider _medClientProvider;
    private readonly IMedClientPersistor _medClientPersistor;
    public MedClientController(IMedClientProvider medClientProvider, IMedClientPersistor medClientPersistor)
    {
        _medClientProvider = medClientProvider;
        _medClientPersistor = medClientPersistor;
    }
    
    // GET
    public IActionResult Index()
    {
        throw new NotImplementedException();
    }
}