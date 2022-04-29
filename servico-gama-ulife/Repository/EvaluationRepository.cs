using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using servico_gama_ulife.Model;
using servico_gama_ulife.Repository.Configuration;
using servico_gama_ulife.Repository.Interface;
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

    }
}
