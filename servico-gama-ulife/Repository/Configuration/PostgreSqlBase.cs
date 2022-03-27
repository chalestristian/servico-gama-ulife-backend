using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;

namespace servico_gama_ulife.Repository.Configuration
{
    public class PostgreSqlBase
    {
        private readonly IConfiguration _configuration;

        protected PostgreSqlBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            string connectionString = _configuration.GetConnectionString("ServicoGamaUlife");
            IDbConnection dbConnection = new NpgsqlConnection(connectionString);
            dbConnection.Open();

            return dbConnection;
        }
        protected virtual int Execute(string sql, IDbConnection connection, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var result = connection.Execute(sql, param, transaction, commandTimeout, commandType: commandType);
            return result;
        }

        protected virtual IEnumerable<T> Query<T>(string sql, IDbConnection connection, object param = null, CommandType? commandType = null) where T : new()
        {
            IEnumerable<T> result = connection.Query<T>(sql, param, commandType: commandType);
            return result;
        }
    }
}
