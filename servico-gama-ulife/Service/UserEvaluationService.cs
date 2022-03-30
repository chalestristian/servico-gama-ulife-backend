using servico_gama_ulife.Enum;
using servico_gama_ulife.Model;
using servico_gama_ulife.Repository.Interface;
using servico_gama_ulife.Service.Request;
using System.Collections.Generic;

namespace servico_gama_ulife.Service
{
    public class UserEvaluationService : IUserEvaluationService
    {
        private readonly IUserEvaluationRepository _userEvaluationRepository;
        public UserEvaluationService(IUserEvaluationRepository userEvaluationRepository)
        {
            _userEvaluationRepository = userEvaluationRepository;
        }
        public UserEvaluationModel AddUserEvaluation(AddUserEvaluation newUserEvaluation)
        {
            var resp = _userEvaluationRepository.AddUserEvaluation(newUserEvaluation);
            return resp;
        }

        public IList<UserEvaluationModel> GetAllUserEvaluation()
        {
            var resp = _userEvaluationRepository.GetAllUserEvaluation();
            return resp;
        }

        public UserEvaluationModel GetUserEvaluationById(int nr_userevaluationid)
        {
            var resp = _userEvaluationRepository.GetUserEvaluationById(nr_userevaluationid);
            return resp;
        }

        public UserEvaluationModel GetUserEvaluationByIdAndUser(int nr_userid, int nr_userevaluationid)
        {
            var resp = _userEvaluationRepository.GetUserEvaluationByIdAndUser(nr_userid, nr_userevaluationid);
            return resp;
        }

        public IList<UserEvaluationModel> GetUserEvaluationByUser(int nr_userid, int typeUser)
        {
            if (typeUser == 1)
            {
                return _userEvaluationRepository.GetUserEvaluationByUser(nr_userid, typeUser);
            }
            else
            {
                throw new System.NotImplementedException("Usuário não corresponde a um Estudante!");
            }
        }

        public UserEvaluationModel UpdateUserEvaluation(UpdateUserEvaluation updateUserEvaluation)
        {
            var resp = _userEvaluationRepository.UpdateUserEvaluation(updateUserEvaluation);
            return resp;
        }
    }
}
