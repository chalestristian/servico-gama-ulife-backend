using servico_gama_ulife.Model;

namespace servico_gama_ulife.Repository.Interface
{
    public interface IUserAuthenticationRepository
    {
        UserAuthenticationModel UserSearch(UserAuthenticationModel userAuth);
    }
}
