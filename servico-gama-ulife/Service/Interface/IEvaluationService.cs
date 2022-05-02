using servico_gama_ulife.Model;
using servico_gama_ulife.Service.Request;
using System.Collections.Generic;

namespace servico_gama_ulife.Service.Interface
{
    public interface IEvaluationService
    {
        bool SaveGrade(int nr_registry, int nr_userevaluationid, SaveGradeModel saveGradeModels);
        IEnumerable<GetUserEvaluation> GetEvaluationByUserId(int nr_userId, int ds_usertypeid);
    }
}
