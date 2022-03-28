using servico_gama_ulife.Model;
using servico_gama_ulife.Repository.Interface;
using servico_gama_ulife.Service.Request;
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
            var resp = _userRepository.GetUserById(nr_registry);
            return resp;
        }

        public IList<UserModel> GetAllUser()
        {
            var resp = _userRepository.GetAllUser();
            return resp;
        }

        public UserModel PutUser(int nr_registry, string Nm_user, string Ds_email)
        {
            var resp = _userRepository.PutUser(nr_registry,Nm_user,Ds_email);
            return resp;
        }

        public string AddUser(AddUser newUser)
        {
            var resp = _userRepository.AddUser(newUser);
            return resp.ToString();
        }
    }
}
