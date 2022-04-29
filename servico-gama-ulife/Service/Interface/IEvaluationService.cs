using servico_gama_ulife.Model;
using System.Collections.Generic;

namespace servico_gama_ulife.Service.Interface
{
    public interface IEvaluationService
    {
        IList<EvaluationModel> GetEvaluation();
    }
}
