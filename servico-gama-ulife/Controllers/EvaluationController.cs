using Microsoft.AspNetCore.Mvc;
using servico_gama_ulife.Mapper;
using servico_gama_ulife.Model;
using servico_gama_ulife.Response;
using servico_gama_ulife.Service.Interface;
using System;
using System.Collections.Generic;

namespace servico_gama_ulife.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationService _evaluationService;
        private readonly IObjectConverter _objectConverter;
        private readonly IUserAuthenticationService _userAuthenticationService;

        public EvaluationController(IEvaluationService evaluationService, IObjectConverter objectConverter, IUserAuthenticationService userAuthenticationService)
        {
            _evaluationService = evaluationService;
            _objectConverter = objectConverter;
            _userAuthenticationService = userAuthenticationService;
        }

        /// <summary>
        /// Retorna todos as avaliações
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetEvaluation()
        {
            IList<EvaluationModel> evaluation = _evaluationService.GetEvaluation();
            return Ok(_objectConverter.Map<IList<EvaluationModel>>(evaluation));
        }

        /// <summary>
        /// Buscar avaliação por id
        /// </summary>
        /// <param name="nr_evaluationid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEvaluationById/{nr_evaluationid}")]
        public IActionResult GetEvaluationById([FromRoute] int nr_evaluationid)
        {
            var evaluation = _evaluationService.GetEvaluationById(nr_evaluationid);
            return Ok(_objectConverter.Map<EvaluationResponse>(evaluation));
        }

        [HttpPost("{nr_registry}/{nr_userevaluationid}")]
        public IActionResult SaveGrade([FromRoute] int nr_registry, [FromRoute] int nr_userevaluationid,
            [FromBody] SaveGradeModel saveGradeModels, [FromHeader] string token)
        {  
            var authetication = _userAuthenticationService.GetUserByToken(token);

            if (authetication.Dt_expirationdate >= DateTime.Now)
            {
                return Ok(_evaluationService.SaveGrade(nr_registry, nr_userevaluationid, saveGradeModels));
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Route("GetEvaluationByUserId")]
        public IActionResult GetEvaluationByUserId([FromHeader]string token)
        { 
            var authetication = _userAuthenticationService.GetUserByToken(token);

            if (authetication.Dt_expirationdate >= DateTime.Now)
            {
                return Ok(_evaluationService.GetEvaluationByUserId(authetication.Nr_userid));
            }
            else
            {
                return Unauthorized();
            } 
        }
    }
}
