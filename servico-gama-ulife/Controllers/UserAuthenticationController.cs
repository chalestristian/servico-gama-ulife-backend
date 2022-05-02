using Microsoft.AspNetCore.Mvc;
using servico_gama_ulife.Controllers.Request;
using servico_gama_ulife.Controllers.ViewModel;
using servico_gama_ulife.Service.Interface;

namespace servico_gama_ulife.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly IUserAuthenticationService _userAuthenticationService;
        public UserAuthenticationController(IUserAuthenticationService iUserAuthenticationService)
        {
            _userAuthenticationService = iUserAuthenticationService;
        }

        [HttpPost]
        public IActionResult UserAutheticationToken([FromBody] UserAuthenticationRequest request)
        {
            var authetication = _userAuthenticationService.ValidAuthenticationToken(request);
            if (authetication != null) return Ok(authetication);
            return Unauthorized();
        }
    }
}
