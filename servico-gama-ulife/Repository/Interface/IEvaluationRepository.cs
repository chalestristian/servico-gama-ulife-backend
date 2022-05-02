using servico_gama_ulife.Model;
using servico_gama_ulife.Service.Request;
using System.Collections.Generic;

namespace servico_gama_ulife.Repository.Interface
{
    public interface IEvaluationRepository
    {
        IList<QuestionsModel> GetQuestionList(int nr_registry);
        bool SaveGrade(int nr_userevaluationid, float media);
        IEnumerable<GetUserEvaluation> GetEvaluationByUserId(int nr_userId);
        IEnumerable<GetUserEvaluation> GetEvaluationByUserId();

    }
}
