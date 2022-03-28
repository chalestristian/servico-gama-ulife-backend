using servico_gama_ulife.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace servico_gama_ulife.Repository.Interface
{
    public interface IApiTesteRepository
    {
        string ApiTesteBanco();
        object BuscarUmUnicoDadoNoBanco(int codigo);       

    }
}
