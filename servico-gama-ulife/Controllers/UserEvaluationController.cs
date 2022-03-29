using Microsoft.AspNetCore.Mvc;
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
    public class UserEvaluationController : ControllerBase
    {
        private readonly IUserEvaluationService _userEvaluationService;
        private readonly IObjectConverter _objectConverter;

        public UserEvaluationController(IUserEvaluationService userEvaluationService, IObjectConverter objectConverter)
        {
            _userEvaluationService = userEvaluationService;
            _objectConverter = objectConverter;
        }

        /// <summary>
        /// Retorna todas as avaliações
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllUserEvaluation()
        {
            var userEvaluation = _userEvaluationService.GetAllUserEvaluation();
            return Ok(_objectConverter.Map<IList<UserEvaluationResponse>>(userEvaluation));
        }

        /// <summary>
        /// Buscar avaliação por id
        /// </summary>
        /// <param name="nr_userevaluationid"></param>
        /// <returns></returns>
        [HttpGet("{nr_userevaluationid}")]
        public IActionResult GetUserEvaluationById([FromRoute] int nr_userevaluationid)
        {
            var userEvaluation = _userEvaluationService.GetUserEvaluationById(nr_userevaluationid);
            return Ok(_objectConverter.Map<UserEvaluationResponse>(userEvaluation));
        }

        /// <summary>
        /// Atualizar nota e status
        /// </summary>
        /// <param name="nr_userevaluationid"></param>
        /// /// <param name="nr_userid"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{nr_userevaluationid}")]
        public IActionResult PutUserEvaluation([FromRoute] int nr_userid, [FromRoute] int nr_userevaluationid, [FromBody] UpdateUserEvaluation request)
        {
            UserEvaluationModel userEvaluation = _userEvaluationService.UpdateUserEvaluation(nr_userid, nr_userevaluationid, request.Nr_grade, request.Ds_hasdone);
            return Ok(_objectConverter.Map<UserEvaluationResponse>(userEvaluation));
        }

        /// <summary>
        /// Cadastrar avaliação
        /// </summary>
        /// <param name="newUserEvaluation"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddUserEvaluation([FromBody] AddUserEvaluation request)
        {
            var userEvaluation = _userEvaluationService.AddUserEvaluation(request);
            return Ok(userEvaluation);
        }

        /// <summary>
        /// Buscar avaliações por usuário
        /// </summary>
        /// <param name="nr_userid"></param>
        /// <returns></returns>
        [HttpGet("{nr_userid}")]
        public IActionResult GetUserEvaluationByUser([FromRoute] int nr_userid)
        {
            var userEvaluation = _userEvaluationService.GetUserEvaluationByUser(nr_userid);
            return Ok(_objectConverter.Map<UserResponse>(userEvaluation));
        }
    }
}
