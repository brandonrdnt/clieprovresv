using Ardiente.Cpr.Application.Dtos;
using Ardiente.Cpr.Application.Interfaces.Persistors;
using Ardiente.Cpr.Application.Interfaces.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ardiente.Cpr.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedProviderController : ControllerBase
    {
        private readonly IMedProviderProvider _medProviderProvider;
        private readonly IMedProviderPersistor _medProviderPersistor;

        public MedProviderController(IMedProviderProvider medProviderProvider, IMedProviderPersistor medProviderPersistor)
        {
            _medProviderProvider = medProviderProvider;
            _medProviderPersistor = medProviderPersistor;
        }
        // GET
        [HttpGet]
        public IActionResult Get()
        {
            List<MedProviderDto> medProviders = _medProviderProvider.GetMedProviders();

            return Ok(medProviders);
        }

        [HttpPost]
        public IActionResult Post(MedProviderDto medProvider)
        {
            _medProviderPersistor.SaveMedProvider(medProvider);
            return Ok();
        }
    }
}
