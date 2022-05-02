using servico_gama_ulife.Model;
using servico_gama_ulife.Repository.Interface;
using servico_gama_ulife.Service.Interface;
using System.Collections.Generic;

namespace servico_gama_ulife.Service
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IQuestionnaireRepository _questionnaireRepository;

        public QuestionnaireService(IQuestionnaireRepository questionnaireRepository)
        {
            _questionnaireRepository = questionnaireRepository;
        }

        public QuestionnaireModel GetQuestionnaireById(int nr_questionnaireid)
        {
            return _questionnaireRepository.GetQuestionnaireById(nr_questionnaireid);
        }
        public IEnumerable<QuestionModel> GetQuestionnaireQuestionsById(int nr_questionnaireid)
        {
            return _questionnaireRepository.GetQuestionnaireQuestionsById(nr_questionnaireid);
        }


    }
}
