using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using servico_gama_ulife.Model;
using servico_gama_ulife.Repository.Configuration;
using servico_gama_ulife.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace servico_gama_ulife.Repository
{
    public class TokenLogRepository : PostgreSqlBase, ITokenLogRepository
    {
        public TokenLogRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public TokenLogModel GetUserByToken(string ds_token)
        {
            string sql = @"select * from token_log tl 
                            inner join ""user"" u on tl.nr_userid = u.nr_userid 
                            where tl.ds_token =:ds_token; ";

            using var connection = GetConnection() as NpgsqlConnection;
            return connection.QueryFirstOrDefault<TokenLogModel>(sql, new { ds_token = ds_token });
        }

        public TokenLogModel InsertToken(TokenLogModel userAuth)
        {
            string sql = @"INSERT INTO token_log
                            (nr_userid, ds_token, dt_creationdate, dt_expirationdate)
                            VALUES(:nr_userid, :ds_token, now(), now() + interval '24 hour');";

            using var connection = GetConnection() as NpgsqlConnection;
            return connection.QueryFirstOrDefault<TokenLogModel>(sql, new { userAuth.Nr_userid,userAuth.Ds_token });
        }

        public void InvalidToken(int userID)
        {
            string sql = @"UPDATE token_log
                           SET dt_expirationdate= now()
                           WHERE nr_userid = :nr_userid
                           and dt_expirationdate > dt_creationdate;";

            DynamicParameters parameters = new();
            parameters.Add("@nr_userid", userID, DbType.Int32, direction: ParameterDirection.Input);

            using var connection = GetConnection() as NpgsqlConnection;
            connection.QueryFirstOrDefault(sql, parameters);
        }

    }
}