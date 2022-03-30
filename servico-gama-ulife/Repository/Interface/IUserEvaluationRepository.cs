using System.Collections.Generic;
using servico_gama_ulife.Enum;
using servico_gama_ulife.Model;
using servico_gama_ulife.Service.Request;

namespace servico_gama_ulife.Repository.Interface
{
    public interface IUserEvaluationRepository
    {
        UserEvaluationModel GetUserEvaluationById(int nr_userevaluationid);
        IList<UserEvaluationModel> GetUserEvaluationByUser(int nr_userid, int typeUser);
        UserEvaluationModel GetUserEvaluationByIdAndUser(int nr_userid, int nr_userevaluationid);
        UserEvaluationModel AddUserEvaluation(AddUserEvaluation newUserEvaluation);
        UserEvaluationModel UpdateUserEvaluation(UpdateUserEvaluation updateUserEvaluation);
        IList<UserEvaluationModel> GetAllUserEvaluation();
    }
}
