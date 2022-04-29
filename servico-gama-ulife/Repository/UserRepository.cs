using Dapper;
using servico_gama_ulife.Model;
using servico_gama_ulife.Repository.Interface;
using Npgsql;
using Microsoft.Extensions.Configuration;
using servico_gama_ulife.Repository.Configuration;
using System.Collections.Generic;
using System.Linq;
using servico_gama_ulife.Service.Request;
using System.Data;

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

            DynamicParameters parameters = new();
            parameters.Add("@nr_registry", nr_registry, DbType.Int64, direction: ParameterDirection.Input);

            using IDbConnection connection = GetConnection() as NpgsqlConnection;
            return connection.QueryFirstOrDefault<UserModel>(sql, parameters);

        }

        public IList<UserModel> GetAllUser()
        {
            string sql = @"SELECT * from ""user"" ";

            using IDbConnection connection = GetConnection() as NpgsqlConnection;
            return connection.Query<UserModel>(sql).ToList();
        }

        public UserModel PutUser(int nr_registry, string nm_user, string ds_email)
        {
            string sql = @"UPDATE ""user"" 
                                SET dt_modifieddate = now(),
                                nm_user = :nm_user,
                                ds_email = :ds_email
                           WHERE nr_registry = :nr_registry";

            DynamicParameters parameters = new();
            parameters.Add("@nr_registry", nr_registry, DbType.Int64, direction: ParameterDirection.Input);
            parameters.Add("@nm_user", nm_user, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@ds_email", ds_email, DbType.String, direction: ParameterDirection.Input);

            using IDbConnection connection = GetConnection() as NpgsqlConnection;
            return connection.QueryFirstOrDefault<UserModel>(sql, parameters);
        }

        public string AddUser(AddUser newUser)
        {
            string sql = @"INSERT into ""user"" (nr_registry,nm_user,ds_email, ds_password, ds_usertypeid,dt_creationdate,dt_modifieddate)	
                            values(:nr_registry, :nm_user, :ds_email,:ds_password,:ds_usertypeid, now(), null)";

            DynamicParameters parameters = new();
            parameters.Add("@nr_registry", newUser.Nr_registry, DbType.Int64, direction: ParameterDirection.Input);
            parameters.Add("@nm_user", newUser.Nm_user, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@ds_email", newUser.Ds_email, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@ds_password", newUser.Ds_password, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@ds_usertypeid", newUser.Ds_usertypeid, DbType.Int64, direction: ParameterDirection.Input);

            using IDbConnection connection = GetConnection() as NpgsqlConnection;
            return connection.Query<string>(sql, parameters).ToString();
        }

        public IList<UserModel> GetAllByType(int nr_type)
        {
            string sql = @"SELECT * from ""user"" where ds_usertypeid = :nr_type";

            DynamicParameters parameters = new();
            parameters.Add("@nr_type", nr_type, DbType.Int64, direction: ParameterDirection.Input);

            using IDbConnection connection = GetConnection() as NpgsqlConnection;
            return connection.Query<UserModel>(sql, parameters).ToList();
        }

        public string DeleteUser(int nr_registry)
        {
            string sql = @"UPDATE ""user"" 
                                SET isActive = false,
                                dt_modifieddate = now()
                           WHERE nr_registry = :nr_registry";

            DynamicParameters parameters = new();
            parameters.Add("@nr_registry", nr_registry, DbType.Int64, direction: ParameterDirection.Input);

            using IDbConnection connection = GetConnection() as NpgsqlConnection;
            return connection.Query<string>(sql, parameters).ToString();
        }
    }
}
