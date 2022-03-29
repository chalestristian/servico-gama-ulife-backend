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

        public IEnumerable<QuestionnaireModel> GetAllQuestionnaire()
        {
            string sql = @"SELECT * FROM questionnaire";

            using var connection = GetConnection() as NpgsqlConnection;
            return connection.Query<QuestionnaireModel>(sql);
        }
        public QuestionnaireModel GetQuestionnaireById(int nr_questionnaireid)
        {
            string sql = @"SELECT * FROM questionnaire where nr_questionnaireid = :nr_questionnaireid";

            using var connection = GetConnection() as NpgsqlConnection;
            return connection.QueryFirstOrDefault<QuestionnaireModel>(sql, new { nr_questionnaireid });
        }

        public IEnumerable<QuestionModel> GetQuestionnaireQuestionsById(int nr_questionnaireid)
        {
            using var connection = GetConnection() as NpgsqlConnection;
            string sqlQuestionList = @"select * from questionnaire_question qq 
                                       join question q on q.nr_questionid = qq.nr_questionid 
                                       where qq.nr_questionnaireid = :nr_questionnaireid";

            IEnumerable<QuestionModel> resultQuestionList = connection.Query<QuestionModel>(sqlQuestionList, new { nr_questionnaireid });

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
