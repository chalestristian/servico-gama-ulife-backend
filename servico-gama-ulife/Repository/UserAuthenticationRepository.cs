﻿using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using servico_gama_ulife.Model;
using servico_gama_ulife.Repository.Configuration;
using servico_gama_ulife.Repository.Interface;
using System.Data;

namespace servico_gama_ulife.Repository
{
    public class UserAuthenticationRepository : PostgreSqlBase, IUserAuthenticationRepository
    {
        public UserAuthenticationRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public UserAuthenticationModel UserSearch(UserAuthenticationModel userAuth)
        {
            string sql = @"select
                        u.nr_userid as Id,
                        u.ds_email as Email,
                        u.nm_user as User,
                        u.""ds_password"" as Password,
                        u.ds_usertypeid as Role,
                        u.IsActive
                        from ""user"" u
                        where u.ds_email = :email and u.""ds_password"" = :password";

            DynamicParameters parameters = new();
            parameters.Add("@email", userAuth.User, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@password", userAuth.Password, DbType.String, direction: ParameterDirection.Input);

            using var connection = GetConnection() as NpgsqlConnection;
            return connection.QueryFirstOrDefault<UserAuthenticationModel>(sql, parameters);
        }
    }
}
