using Microsoft.AspNetCore.Mvc;
using servico_gama_ulife.Mapper;
using servico_gama_ulife.Model;
using servico_gama_ulife.Service.Interface;
using System.Collections.Generic;

namespace servico_gama_ulife.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationService _evaluationService;
        private readonly IObjectConverter _objectConverter;

        public EvaluationController(IEvaluationService evaluationService, IObjectConverter objectConverter)
        {
            _evaluationService = evaluationService;
            _objectConverter = objectConverter;
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

    }
}
