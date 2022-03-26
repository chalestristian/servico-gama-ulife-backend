using servico_gama_ulife.Repository.Interface;
using servico_gama_ulife.Service.Interface;

namespace servico_gama_ulife.Service
{
    public class ApiTesteService : IApiTesteService
    {
        private readonly IApiTesteRepository _apiTesteRepository;

        public ApiTesteService(IApiTesteRepository apiTesteRepository)
        {
            _apiTesteRepository = apiTesteRepository;
        }
        public string ApiTeste()
        {
            return _apiTesteRepository.ApiTesteBanco();
        }
    }
}
