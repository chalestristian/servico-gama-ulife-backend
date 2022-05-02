using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using servico_gama_ulife.Controllers.Request;
using servico_gama_ulife.Mapper;
using servico_gama_ulife.Model;
using servico_gama_ulife.Repository.Interface;
using servico_gama_ulife.Service.Interface;
using servico_gama_ulife.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace servico_gama_ulife.Service
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IObjectConverter _objectConverter;
        private readonly IConfiguration _configuration;
        private readonly IUserAuthenticationRepository _userAuthenticationRepository;
        private readonly ITokenLogRepository _tokenLogRepository;
        private readonly IUserRepository _userRepository;
        public UserAuthenticationService(IObjectConverter objectConverter,
            IConfiguration configuration,
            IUserAuthenticationRepository userAuthenticationRepository,
            ITokenLogRepository tokenLogRepository,
            IUserRepository userRepository)
        {
            _objectConverter = objectConverter;
            _configuration = configuration;
            _userAuthenticationRepository = userAuthenticationRepository;
            _tokenLogRepository = tokenLogRepository;
            _userRepository = userRepository;
        }

        public TokenLogModel GetUserByToken(string token)
        {
            return _tokenLogRepository.GetUserByToken(token);  
        }

        public AuthResponse ValidAuthenticationToken(UserAuthenticationRequest request)
        {
            UserAuthenticationModel user = _objectConverter.Map<UserAuthenticationModel>(request);
            UserAuthenticationModel userAuth = _userAuthenticationRepository.UserSearch(user);

            if (userAuth == null)
            {
                return null;
            }
            if (!userAuth.IsActive) return null;


            var allChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var resultToken = new string(
               Enumerable.Repeat(allChar, 30)
               .Select(token => token[random.Next(token.Length)]).ToArray());

            string authToken = resultToken.ToString();
              
            _tokenLogRepository.InvalidToken(userAuth.Id);
            _tokenLogRepository.InsertToken(new TokenLogModel
            {
                Ds_token = authToken,
                Nr_userid = userAuth.Id

            });

            return new AuthResponse
            {
                Id = userAuth.Id,
                Name = userAuth.User,
                Role = Int32.Parse(userAuth.Role),
                Token = authToken
            };
        }
    }
}
