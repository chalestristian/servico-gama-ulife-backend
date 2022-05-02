using Microsoft.AspNetCore.Mvc;
using servico_gama_ulife.Mapper;
using servico_gama_ulife.Model;
using servico_gama_ulife.Response;
using servico_gama_ulife.Service;
using servico_gama_ulife.Service.Interface;
using servico_gama_ulife.Service.Request;
using System;
using System.Collections.Generic;

namespace servico_gama_ulife.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IObjectConverter _objectConverter;
        private readonly IUserAuthenticationService _userAuthenticationService;

        public UserController(IUserService userService, IObjectConverter objectConverter, IUserAuthenticationService userAuthenticationService)
        {
            _userService = userService;
            _objectConverter = objectConverter;
            _userAuthenticationService = userAuthenticationService;
        }


        [HttpGet]
        public IActionResult GetAllUser()
        {
            IList<UserModel> user = _userService.GetAllUser();
            return Ok(_objectConverter.Map<IList<UserResponse>>(user));
        }


        [HttpGet("{nr_registry}")]
        public IActionResult GetUserById([FromRoute] int nr_registry)
        {
            UserModel user = _userService.GetUserById(nr_registry);
            if(user is null) 
                return NotFound("Usuário não encontrado!");
            return Ok(_objectConverter.Map<UserResponse>(user));
        }


        [HttpPut("{nr_registry}")]
        public IActionResult PutUser([FromRoute] int nr_registry, [FromBody] EditUser request)
        {
            UserModel user = _userService.PutUser(nr_registry, request.Nm_user, request.Ds_email);
            return Ok(_objectConverter.Map<UserResponse>(user));
        }

        [HttpGet("UserEvaluations")]
        public IActionResult GetAllUserEvalations([FromHeader] string token)
        {
            var authetication = _userAuthenticationService.GetUserByToken(token); 

            if (authetication.Dt_expirationdate >= DateTime.Now) 
            { 
                return Ok(_userService.GetAllUserEvalations(authetication.Nr_userid));
            }
            else
            {
                return Unauthorized();
            } 
        }


        [HttpPut("{user_Id}/{isActive}")]
        public IActionResult SetUserStatus([FromRoute] int user_Id, [FromRoute] bool isActive)
        {
            var result = _userService.PutUsetStatus(user_Id, isActive);

            return Ok(result);
        }
    }
}
