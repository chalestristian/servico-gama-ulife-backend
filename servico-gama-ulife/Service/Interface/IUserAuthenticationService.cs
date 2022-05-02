using servico_gama_ulife.Controllers.Request;
using servico_gama_ulife.Model;
using servico_gama_ulife.ViewModels;

namespace servico_gama_ulife.Service.Interface
{
    public interface IUserAuthenticationService
    {
        AuthResponse ValidAuthenticationToken(UserAuthenticationRequest request);
        TokenLogModel GetUserByToken(string token);

    }
}
