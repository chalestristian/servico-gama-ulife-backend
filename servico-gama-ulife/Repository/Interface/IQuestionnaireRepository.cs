using servico_gama_ulife.Model;
using System.Collections.Generic;

namespace servico_gama_ulife.Repository.Interface
{
    public interface IQuestionnaireRepository
    {
        IEnumerable<QuestionnaireModel> GetAllQuestionnaire();
        QuestionnaireModel GetQuestionnaireById(int nr_userevaluationid);
        IEnumerable<QuestionModel> GetQuestionnaireQuestionsById(int nr_userevaluationid);
    }

}
