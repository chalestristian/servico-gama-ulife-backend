using servico_gama_ulife.Repository.Interface;

namespace servico_gama_ulife.Repository
{
    public class ApiTesteRepository : IApiTesteRepository
    {
        public string ApiTesteBanco()
        {
            return "Bem vindo ao teste!";
        }
    }
}
