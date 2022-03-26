using Microsoft.AspNetCore.Mvc;
using servico_gama_ulife.Service.Interface;

namespace servico_gama_ulife.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiTeste : ControllerBase
    {
        private readonly IApiTesteService _apiTesteService;
        public ApiTeste(IApiTesteService iApiTesteService)
        {
            _apiTesteService = iApiTesteService;
        }

        [HttpGet("obter")]
        public IActionResult ObterUmaString()
        {
            string clientes = _apiTesteService.ApiTeste();
            return Ok(clientes);
        }
    }
}
