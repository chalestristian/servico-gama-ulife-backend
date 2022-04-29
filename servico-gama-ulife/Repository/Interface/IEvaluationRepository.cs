using servico_gama_ulife.Model;
using System.Collections.Generic;

namespace servico_gama_ulife.Repository.Interface
{
    public interface IEvaluationRepository
    {
        IList<EvaluationModel> GetEvaluation();
        EvaluationModel GetEvaluationById(int nr_evaluationid);

    }
}
