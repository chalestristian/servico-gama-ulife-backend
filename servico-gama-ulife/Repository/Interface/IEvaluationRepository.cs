using servico_gama_ulife.Model;
using System.Collections.Generic;

namespace servico_gama_ulife.Repository.Interface
{
    public interface IEvaluationRepository
    {
        IList<EvaluationModel> GetEvaluation();
        IList<QuestionsModel> GetQuestionList(int nr_registry);
        bool SaveGrade(int nr_userevaluationid, float media);
        EvaluationModel GetEvaluationById(int nr_evaluationid);

    }
}
