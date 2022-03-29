using servico_gama_ulife.Controllers.Request;

namespace servico_gama_ulife.Service.Interface
{
    public interface IUserAuthenticationService
    {
        string ValidAuthenticationToken(UserAuthenticationRequest request);
    }
}
