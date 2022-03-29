using servico_gama_ulife.Model;
using System.Collections.Generic;

namespace servico_gama_ulife.Service.Interface
{
    public interface IQuestionnaireService
    {
        IEnumerable<QuestionnaireModel> GetAllQUestionnaire();
        QuestionnaireModel GetQuestionnaireById(int nr_questionnaireid);
        IEnumerable<QuestionModel> GetQuestionnaireQuestionsById(int nr_questionnaireid);
    }
}
