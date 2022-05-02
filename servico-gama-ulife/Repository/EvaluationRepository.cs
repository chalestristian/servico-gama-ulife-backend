using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using servico_gama_ulife.Model;
using servico_gama_ulife.Repository.Configuration;
using servico_gama_ulife.Repository.Interface;
using servico_gama_ulife.Service.Request;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace servico_gama_ulife.Repository
{
    public class EvaluationRepository : PostgreSqlBase, IEvaluationRepository
    {
        public EvaluationRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public IList<EvaluationModel> GetEvaluation()
        {
            string sql = @"select e.nr_evaluationid, e.nm_evaluation, e.nr_questionnaireid, q.nm_questionnaire 
                            from evaluation e 
                            join questionnaire q on q.nr_questionnaireid = e.nr_questionnaireid ";

            using IDbConnection connection = GetConnection() as NpgsqlConnection;
            return connection.Query<EvaluationModel>(sql).ToList();
        }

        public IList<QuestionsModel> GetQuestionList(int nr_registry)
        {
            string sql = @"select qu.nr_questionid, a.*
                            from questionnaire q
                            inner join questionnaire_question qq ON q.nr_questionnaireid = qq.nr_questionnaireid
                            inner join question qu on qu.nr_questionid = qq.nr_questionid
                            inner join question_alternatives qa on qa.nr_questionid = qu.nr_questionid
                            inner join alternatives a on a.nr_alternativesid = qa.nr_alternativesid
                            where q.nr_questionnaireid = :nr_registry";

            DynamicParameters parameters = new();
            parameters.Add("@nr_registry", nr_registry, DbType.Int64, direction: ParameterDirection.Input);
            using IDbConnection connection = GetConnection() as NpgsqlConnection;
            return connection.Query<QuestionsModel>(sql, parameters).ToList();
        }

        public bool SaveGrade(int nr_userevaluationid, float media)
        {
            string sql = @"update 
                            user_evaluation
                            set ds_hasdone = true,
                            dr_grade = :dr_grade,
                            dt_modifieddate = now()
                            where nr_userevaluationid = :nr_userevaluationid";

            DynamicParameters parameters = new();
            parameters.Add("@nr_userevaluationid", nr_userevaluationid, DbType.Int64, direction: ParameterDirection.Input);
            parameters.Add("@dr_grade", media, DbType.Single, direction: ParameterDirection.Input);
            using IDbConnection connection = GetConnection() as NpgsqlConnection;
            connection.Query(sql, parameters);
            return true;
        }
        public EvaluationModel GetEvaluationById(int nr_evaluationid)
        {
            string sql = @"SELECT * from ""evaluation""
                        WHERE nr_evaluationid = :nr_evaluationid";

            var parameters = new DynamicParameters();
            parameters.Add("@nr_evaluationid", nr_evaluationid, DbType.Int32, direction: ParameterDirection.Input);



            using (var connection = GetConnection() as NpgsqlConnection)
            {
                return connection.QueryFirstOrDefault<EvaluationModel>(sql, parameters);
            }
        }
        public IEnumerable<GetUserEvaluation> GetEvaluationByUserId(int nr_userId)
        {
            string sql = @"select 
                        	u.nm_user, 
                        	e.nm_evaluation, 
                        	q.nm_questionnaire,
                        	q.ds_questionnaire,
	                        q.nr_questionnaireid,
                            ue.nr_userevaluationid
                        from user_evaluation ue 
                        join evaluation e on e.nr_evaluationid = ue.nr_evaluationid 
                        join questionnaire q on q.nr_questionnaireid  = e.nr_questionnaireid 
                        join ""user"" u on u.nr_userid = q.nr_userid 
                        where ue.nr_userid = :nr_userId
                        and ue.ds_hasdone = false";

            var parameters = new DynamicParameters();
            parameters.Add("@nr_userId", nr_userId, DbType.Int32, direction: ParameterDirection.Input);

            using (var connection = GetConnection() as NpgsqlConnection)
            {
                return connection.Query<GetUserEvaluation>(sql, parameters);
            }
        } 
    }
} 