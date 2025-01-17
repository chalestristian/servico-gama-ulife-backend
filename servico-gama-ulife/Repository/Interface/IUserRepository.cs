﻿using Microsoft.AspNetCore.Mvc;
using servico_gama_ulife.Model;
using servico_gama_ulife.Service.Request;
using System.Collections.Generic;

namespace servico_gama_ulife.Repository.Interface
{
    public interface IUserRepository
    {
        UserModel GetUserById(int nr_registry);
        UserModel PutUser(int nr_registry, string nm_user, string ds_email);
        IList<UserModel> GetAllUser();
        IList<object> GetAllUserEvalations(int user_id);
        bool PutUserSituation(int user_id, bool isActive);
    }
}
