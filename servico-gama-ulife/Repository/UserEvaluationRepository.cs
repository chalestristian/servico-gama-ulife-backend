using Dapper;
using servico_gama_ulife.Model;
using servico_gama_ulife.Repository.Interface;
using Npgsql;
using servico_gama_ulife.Repository.Configuration;
using System.Collections.Generic;
using System.Linq;
using servico_gama_ulife.Service.Request;
using System.Data;
using Microsoft.Extensions.Configuration;
using servico_gama_ulife.Enum;

namespace servico_gama_ulife.Repository
{
    public class UserEvaluationRepository : PostgreSqlBase, IUserEvaluationRepository
    {
        public UserEvaluationRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public UserEvaluationModel AddUserEvaluation(AddUserEvaluation newUserEvaluation)
        {
            string sql = @"INSERT into ""user_evaluation"" (nr_userid, nr_evaluationid, dr_grade, ds_hasdone, dt_creationdate, dt_modifieddate)	
                            values(:nr_userid, :nr_evaluationid, :dr_grade,:ds_hasdone, now(), null)";

            var parameters = new DynamicParameters();
            parameters.Add("@nr_userid", newUserEvaluation.Nr_userid, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@nr_evaluationid", newUserEvaluation.Nr_evaluationid, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@dr_grade", newUserEvaluation.Dr_grade, DbType.Double, direction: ParameterDirection.Input);
            parameters.Add("@ds_hasdone", newUserEvaluation.Ds_hasdone, DbType.Boolean, direction: ParameterDirection.Input);


            using (var connection = GetConnection() as NpgsqlConnection)
            {
                return connection.QueryFirstOrDefault<UserEvaluationModel>(sql, parameters);
            }
        }

        public IList<UserEvaluationModel> GetAllUserEvaluation()
        {
            string sql = @"SELECT * from ""user_evaluation"" ";

            using (var connection = GetConnection() as NpgsqlConnection)
            {
                return connection.Query<UserEvaluationModel>(sql).ToList();
            }
        }

        public UserEvaluationModel GetUserEvaluationById(int nr_userevaluationid)
        {
            string sql = @"SELECT * from ""user_evaluation"" where nr_userevaluationid = :nr_userevaluationid";

            var parameters = new DynamicParameters();
            parameters.Add("@nr_userevaluationid", nr_userevaluationid, DbType.Int32, direction: ParameterDirection.Input);


            using (var connection = GetConnection() as NpgsqlConnection)
            {
                return connection.QueryFirstOrDefault<UserEvaluationModel>(sql, parameters);
            }
        }

        public UserEvaluationModel GetUserEvaluationByIdAndUser(int nr_userid, int nr_userevaluationid)
        {
            string sql = @"SELECT * from ""user_evaluation""
                                    WHERE nr_userevaluationid = :nr_userevaluationid
                                      AND nr_userid = :nr_userid";

            var parameters = new DynamicParameters();
            parameters.Add("@nr_userevaluationid", nr_userevaluationid, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@nr_userid", nr_userid, DbType.Int32, direction: ParameterDirection.Input);


            using (var connection = GetConnection() as NpgsqlConnection)
            {
                return connection.QueryFirstOrDefault<UserEvaluationModel>(sql, parameters);
            }
        }

        public IList<UserEvaluationModel> GetUserEvaluationByUser(int nr_userid, int typeUser)
        {
            string sql = @"SELECT * from ""user_evaluation"" where nr_userid = :nr_userid";

            var parameters = new DynamicParameters();
            parameters.Add("@nr_userid", nr_userid, DbType.Int32, direction: ParameterDirection.Input);

            using (var connection = GetConnection() as NpgsqlConnection)
            {
                return connection.Query<UserEvaluationModel>(sql, parameters).ToList();
            }
        }

        public UserEvaluationModel UpdateUserEvaluation(UpdateUserEvaluation updateUserEvaluation)
        {
            string sql = @"UPDATE ""user_evaluation"" 
                                SET dt_modifieddate = now(),
                                    dr_grade = :dr_grade,
                                    ds_hasdone = :ds_hasdone
                              WHERE nr_userevaluationid = :nr_userevaluationid
                                AND nr_userid = :nr_userid";

            var parameters = new DynamicParameters();
            parameters.Add("@nr_userid", updateUserEvaluation.Nr_userid, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@nr_userevaluationid", updateUserEvaluation.Nr_userevaluationid, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@dr_grade", updateUserEvaluation.Dr_grade, DbType.Double, direction: ParameterDirection.Input);
            parameters.Add("@ds_hasdone", updateUserEvaluation.Ds_hasdone, DbType.Boolean, direction: ParameterDirection.Input);


            using (var connection = GetConnection() as NpgsqlConnection)
            {
                return connection.QueryFirstOrDefault<UserEvaluationModel>(sql, parameters);
            }
        }
    }
}
