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


        public IList<object> GetAllUserEvalations(int user_id)
        {
            string sql = @"select 
                            e.nm_evaluation,
                            q.nm_questionnaire,
                            u.nm_user,
                            q.ds_questionnaire,
                            ue.dr_grade,
                            ue.dt_creationdate,
                            ue.dt_modifieddate 
                            from user_evaluation ue
                            inner join evaluation e on e.nr_evaluationid = ue.nr_evaluationid 
                            inner join ""user"" u on u.nr_userid = e.nr_userid 
                            inner join questionnaire q on q.nr_questionnaireid = e.nr_questionnaireid
                            where ue.nr_userid =:user_id;";

            DynamicParameters parameters = new();
            parameters.Add("@user_id", user_id, DbType.Int64, direction: ParameterDirection.Input);

            using IDbConnection connection = GetConnection() as NpgsqlConnection;
            return connection.Query<object>(sql, parameters).ToList();
        }

        public bool PutUserSituation(int user_id, bool isActive)
        {
            string sql = @"UPDATE ""user""
                            SET isActive = :isActive
                            WHERE nr_userid = :nr_userid;";

            DynamicParameters parameters = new();
            parameters.Add("@nr_userid", user_id, DbType.Int64, direction: ParameterDirection.Input);
            parameters.Add("@isActive", isActive, DbType.Boolean, direction: ParameterDirection.Input);

            using IDbConnection connection = GetConnection() as NpgsqlConnection;
            connection.Query(sql, parameters);
            return true;
        }
    }
}
