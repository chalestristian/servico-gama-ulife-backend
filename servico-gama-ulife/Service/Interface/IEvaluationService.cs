using servico_gama_ulife.Model;
using System.Collections.Generic;

namespace servico_gama_ulife.Service.Interface
{
    public interface IEvaluationService
    {
        IList<EvaluationModel> GetEvaluation();
        bool SaveGrade(int nr_registry, int nr_userevaluationid,
             SaveGradeModel saveGradeModels);
        EvaluationModel GetEvaluationById(int nr_evaluationid);

    }
}
