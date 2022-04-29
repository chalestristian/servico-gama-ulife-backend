﻿using Microsoft.AspNetCore.Mvc;
using servico_gama_ulife.Mapper;
using servico_gama_ulife.Model;
using servico_gama_ulife.Response;
using servico_gama_ulife.Service;
using servico_gama_ulife.Service.Request;
using System.Collections.Generic;

namespace servico_gama_ulife.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IObjectConverter _objectConverter;

        public UserController(IUserService userService, IObjectConverter objectConverter)
        {
            _userService = userService;
            _objectConverter = objectConverter;
        }

        /// <summary>
        /// Retorna todos os usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllUser()
        {
            IList<UserModel> user = _userService.GetAllUser();
            return Ok(_objectConverter.Map<IList<UserResponse>>(user));
        }

        /// <summary>
        /// Buscar usuário por número de matrícula
        /// </summary>
        /// <param name="nr_registry"></param>
        /// <returns></returns>
        [HttpGet("{nr_registry}")]
        public IActionResult GetUserById([FromRoute] int nr_registry)
        {
            UserModel user = _userService.GetUserById(nr_registry);
            if(user is null) 
                return NotFound("Usuário não encontrado!");
            return Ok(_objectConverter.Map<UserResponse>(user));
        }

        /// <summary>
        /// Altera o valor da flag 'isActive' para false, caso o usuário for inativado
        /// </summary>
        /// <param name="nr_registry"></param>
        /// <returns></returns>
        [HttpDelete("{nr_registry}")]
        public IActionResult DeleteUser([FromRoute] int nr_registry)
        {
            var userExist = _userService.GetUserById(nr_registry);
            if(userExist is null)
                return NotFound("Usuário não encontrado!");         
            return Ok(_userService.DeleteUser(nr_registry));
        }
        /// <summary>
        /// Atualizar nome e email do usuário
        /// </summary>
        /// <param name="nr_registry"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{nr_registry}")]
        public IActionResult PutUser([FromRoute] int nr_registry, [FromBody] EditUser request)
        {
            UserModel user = _userService.PutUser(nr_registry, request.Nm_user, request.Ds_email);
            return Ok(_objectConverter.Map<UserResponse>(user));
        }

        /// <summary>
        /// Cadastrar novo usuário
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddUser([FromBody] AddUser request)
        {
            string user = _userService.AddUser(request);
            return Ok(user);
        }

        /// <summary>
        /// Buscar todos os usuários pelo tipo ( 1-Estudante ou 2-Professor )
        /// </summary>
        /// <param name="nr_registry"></param>
        /// <returns></returns>
        [HttpGet("type/{nr_type}")]
        public IActionResult GetAllByType([FromRoute] int nr_type)
        {
            IList<UserModel> type = _userService.GetAllByType(nr_type);
            if(type.Count == 0) {
                return BadRequest("Tipo não encontrado!");
            }
            IList<UserModel> user = _userService.GetAllByType(nr_type);
            return Ok(_objectConverter.Map<IList<UserResponse>>(user));
        }
    }
}
