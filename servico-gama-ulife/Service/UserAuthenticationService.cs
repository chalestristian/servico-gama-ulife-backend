using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using servico_gama_ulife.Controllers.Request;
using servico_gama_ulife.Mapper;
using servico_gama_ulife.Model;
using servico_gama_ulife.Repository.Interface;
using servico_gama_ulife.Service.Interface;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace servico_gama_ulife.Service
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IObjectConverter _objectConverter;
        private readonly IConfiguration _configuration;
        private readonly IUserAuthenticationRepository _userAuthenticationRepository;
        public UserAuthenticationService(IObjectConverter objectConverter,
            IConfiguration configuration,
            IUserAuthenticationRepository userAuthenticationRepository)
        {
            _objectConverter = objectConverter;
            _configuration = configuration;
            _userAuthenticationRepository = userAuthenticationRepository;
        }

        public string ValidAuthenticationToken(UserAuthenticationRequest request)
        {
            UserAuthenticationModel user = _objectConverter.Map<UserAuthenticationModel>(request);
            UserAuthenticationModel userAuth = _userAuthenticationRepository.UserSearch(user);

            if (!userAuth.Any())
            {
                return null;
            }

            JwtSecurityTokenHandler tokenHandler = new();
            var key = Encoding.ASCII.GetBytes(_configuration.GetConnectionString("HashJWt"));
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, userAuth.User),
                    new Claim(ClaimTypes.Role, userAuth.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(40),
                SigningCredentials =
                    new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
