using Microsoft.AspNetCore.Mvc;
using servico_gama_ulife.Model;
using servico_gama_ulife.Service.Request;
using System.Collections.Generic;

namespace servico_gama_ulife.Service
{
    public interface IUserService
    {
        UserModel GetUserById(int nr_registry);
        UserModel PutUser(int nr_registry,string Nm_user, string Ds_email);
        IList<UserModel> GetAllUser();
        IList<object> GetAllUserEvalations(int user_id);
        bool PutUsetStatus(int user_id, bool isActive);
    }
}