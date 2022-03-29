using servico_gama_ulife.Model;
using servico_gama_ulife.Repository.Interface;
using servico_gama_ulife.Service.Interface;
using System.Collections.Generic;

namespace servico_gama_ulife.Service
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IQuestionnaireRepository _questionnaireRepository;
        private readonly IUserRepository _userRepository;

        public QuestionnaireService(IQuestionnaireRepository questionnaireRepository, IUserRepository userRepository)
        {
            _questionnaireRepository = questionnaireRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<QuestionnaireModel> GetAllQUestionnaire()
        {
            return _questionnaireRepository.GetAllQuestionnaire();
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
