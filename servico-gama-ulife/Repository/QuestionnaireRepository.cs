using servico_gama_ulife.Repository.Interface;
using Microsoft.Extensions.Configuration;
using servico_gama_ulife.Repository.Configuration;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using servico_gama_ulife.Model;
using Dapper;
using System.Data;

namespace servico_gama_ulife.Repository
{
    public class QuestionnaireRepository : PostgreSqlBase, IQuestionnaireRepository
    {
        public QuestionnaireRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public QuestionnaireModel GetQuestionnaireById(int nr_userevaluationid)
        {
            string sql = @"select * from user_evaluation ue 
                            inner join evaluation e on e.nr_evaluationid  = ue.nr_evaluationid 
                            inner join questionnaire q on q.nr_questionnaireid = e.nr_questionnaireid 
                            where ue.nr_userevaluationid = :nr_userevaluationid";

            using var connection = GetConnection() as NpgsqlConnection;
            return connection.QueryFirstOrDefault<QuestionnaireModel>(sql, new { nr_userevaluationid });
        }

        public IEnumerable<QuestionModel> GetQuestionnaireQuestionsById(int nr_userevaluationid)
        {
            using var connection = GetConnection() as NpgsqlConnection;
            string sqlQuestionList = @"select * from user_evaluation ue 
                                        inner join evaluation e on ue.nr_evaluationid = e.nr_evaluationid 
                                        inner join questionnaire q on q.nr_questionnaireid  = e.nr_questionnaireid 
                                        inner join questionnaire_question qq on qq.nr_questionnaireid  = e.nr_questionnaireid 
                                        inner join question q2 on q2.nr_questionid  = qq.nr_questionid 
                                        where ue.nr_userevaluationid = :nr_userevaluationid";

            IEnumerable<QuestionModel> resultQuestionList = connection.Query<QuestionModel>(sqlQuestionList, new { nr_userevaluationid });

            if (resultQuestionList.Any())
            {
                foreach (var (questionnarie, resultAlternative) in
                           from QuestionModel questionnarie in resultQuestionList
                           let sqlAlternativeList = @"select a.* from question_alternatives qa 
                                                    inner join alternatives a ON a.nr_alternativesid = qa.nr_alternativesid 
                                                    where qa.nr_questionid = :nr_questionid"
                           let resultAlternative = connection.Query<AlternativesModel>(sqlAlternativeList, new { questionnarie.Nr_questionid })
                           where resultAlternative != null
                           select (questionnarie, resultAlternative))
                {
                    questionnarie.Alternatives = new List<AlternativesModel>();
                    questionnarie.Alternatives.AddRange(resultAlternative);
                }
            }
            return resultQuestionList;
        }
    }
}
