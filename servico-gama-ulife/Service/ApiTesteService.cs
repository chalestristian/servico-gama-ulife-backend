using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using servico_gama_ulife.Model;
using servico_gama_ulife.Repository.Interface;
using servico_gama_ulife.Service.Interface;
using System.Threading.Tasks;

namespace servico_gama_ulife.Service
{
    public class ApiTesteService : IApiTesteService
    {
        private readonly IApiTesteRepository _apiTesteRepository;
        private readonly ILogger<UserModel> _logger;

        public ApiTesteService(IApiTesteRepository apiTesteRepository, ILogger<UserModel> logger)
        {
            _apiTesteRepository = apiTesteRepository;
            _logger = logger;
        }
        public string ApiTeste()
        {
            return _apiTesteRepository.ApiTesteBanco();
        }
       
    }
}
