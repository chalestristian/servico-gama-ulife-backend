﻿using Dapper;
using servico_gama_ulife.Model;
using servico_gama_ulife.Repository.Interface;
using Npgsql;
using Microsoft.Extensions.Configuration;
using servico_gama_ulife.Repository.Configuration;
using System.Collections.Generic;
using System.Linq;
using servico_gama_ulife.Service.Request;

namespace servico_gama_ulife.Repository
{
    public class UserRepository : PostgreSqlBase, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public UserModel GetUserById(int nr_registry)
        {
            string sql = @"SELECT * from ""user"" where nr_registry = :nr_registry";

            var parameters = new DynamicParameters();
            parameters.Add("@nr_registry", nr_registry, System.Data.DbType.Int64, direction: System.Data.ParameterDirection.Input);


            using (var connection = GetConnection() as NpgsqlConnection)
            {
                return connection.QueryFirstOrDefault<UserModel>(sql, parameters);
            }

        }

        public IList<UserModel> GetAllUser()
        {
            string sql = @"SELECT * from ""user"" ";

            using (var connection = GetConnection() as NpgsqlConnection)
            {
                return connection.Query<UserModel>(sql).ToList();
            }
        }

        public UserModel PutUser(int nr_registry, string nm_user, string ds_email)
        {
            string sql = @"UPDATE ""user"" 
                                SET dt_modifieddate = now(),
                                nm_user = :nm_user,
                                ds_email = :ds_email
                           WHERE nr_registry = :nr_registry";

            var parameters = new DynamicParameters();
            parameters.Add("@nr_registry", nr_registry, System.Data.DbType.Int64, direction: System.Data.ParameterDirection.Input);
            parameters.Add("@nm_user", nm_user, System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            parameters.Add("@ds_email", ds_email, System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);


            using (var connection = GetConnection() as NpgsqlConnection)
            {
                return connection.QueryFirstOrDefault<UserModel>(sql, parameters);
            }
        }

        public string AddUser(AddUser newUser)
        {
            string sql = @"INSERT into ""user"" (nr_registry,nm_user,ds_email, ds_usertypeid,dt_creationdate,dt_modifieddate)	
                            values(:nr_registry, :nm_user, :ds_email,:ds_usertypeid,now(),null)";

            var parameters = new DynamicParameters();
            parameters.Add("@nr_registry", newUser.Nr_registry, System.Data.DbType.Int64, direction: System.Data.ParameterDirection.Input);
            parameters.Add("@nm_user", newUser.Nm_user, System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            parameters.Add("@ds_email", newUser.Ds_email, System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            parameters.Add("@ds_usertypeid", newUser.Ds_usertypeid, System.Data.DbType.Int64, direction: System.Data.ParameterDirection.Input);


            using (var connection = GetConnection() as NpgsqlConnection)
            {
                return connection.Query<string>(sql, parameters).ToString();
            }
        }

    }
}