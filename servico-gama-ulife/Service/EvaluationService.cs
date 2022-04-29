using servico_gama_ulife.Model;
using servico_gama_ulife.Repository.Interface;
using servico_gama_ulife.Service.Interface;
using System.Collections.Generic;

namespace servico_gama_ulife.Service
{
    public class EvaluationService : IEvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public EvaluationService(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public IList<EvaluationModel> GetEvaluation()
        {
            return _evaluationRepository.GetEvaluation();
        }

        public EvaluationModel GetEvaluationById(int nr_evaluationid)
        {
            var resp = _evaluationRepository.GetEvaluationById(nr_evaluationid);
            return resp;
        }

    }
}
