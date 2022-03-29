using servico_gama_ulife.Repository.Interface;
using Microsoft.Extensions.Configuration;
using servico_gama_ulife.Repository.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace servico_gama_ulife.Repository
{
    public class ApiTesteRepository : PostgreSqlBase, IApiTesteRepository
    {

        public ApiTesteRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public string ApiTesteBanco()
        {
            return "Bem vindo ao teste!";
        }

        public void ExecutarUpdateOuInsertNoBanco()
        {
            string sql = $@"Sua query aqui !!!";

            using IDbConnection connection = GetConnection() as NpgsqlConnection;
            Execute(sql, connection);
        }

        public IEnumerable<object> BuscarDadosNoBancoAtravesDeUmObjetoEspecifico(int codigo)
        {
            IEnumerable<object> teste = null;
            string sql = $@"Sua query aqui !! {codigo}";

            using IDbConnection connection = GetConnection() as NpgsqlConnection;
            return Query<object>(sql, connection);

        }

        public object BuscarUmUnicoDadoNoBanco(int codigo)
        {
            object teste = null;
            string sql = $@"Sua query aqui{codigo}";

            using IDbConnection connection = GetConnection() as NpgsqlConnection;
            return Query<object>(sql, connection).FirstOrDefault();
        }
    }
}
