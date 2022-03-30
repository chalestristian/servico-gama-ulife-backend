using servico_gama_ulife.Model;
using servico_gama_ulife.Repository.Interface;
using servico_gama_ulife.Service.Request;
using System;
using System.Collections.Generic;

namespace servico_gama_ulife.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel GetUserById(int nr_registry)
        {
            return _userRepository.GetUserById(nr_registry);
        }

        public IList<UserModel> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        public UserModel PutUser(int nr_registry, string Nm_user, string Ds_email)
        {
            return _userRepository.PutUser(nr_registry, Nm_user, Ds_email);
        }

        public string AddUser(AddUser newUser)
        {
            return _userRepository.AddUser(newUser);
        }

        public IList<UserModel> GetAllByType(int nr_type)
        {
            return (nr_type == (int)Enum.TypeUser.Estudante || nr_type == (int)Enum.TypeUser.Professor)
                      ? _userRepository.GetAllByType(nr_type)
                      : throw new Exception("Tipo de usuário não encontrado!");
        }
    }
}
