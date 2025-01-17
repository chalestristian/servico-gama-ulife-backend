﻿using Microsoft.AspNetCore.Mvc;
using servico_gama_ulife.Mapper;
using servico_gama_ulife.Model;
using servico_gama_ulife.Service.Interface;
using servico_gama_ulife.ViewModels;
using System.Collections.Generic;

namespace servico_gama_ulife.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionnaireController : Controller
    {
        private readonly IQuestionnaireService _questionnaireService;
        private readonly IObjectConverter _objectConverter;

        public QuestionnaireController(IQuestionnaireService questionnaireService, IObjectConverter objectConverter)
        {
            _questionnaireService = questionnaireService;
            _objectConverter = objectConverter;
        }

        [HttpGet]
        [Route("{nr_questionnaireid}")]
        public IActionResult GetQuestionnaireById([FromRoute] int nr_questionnaireid)
        {
            QuestionnaireModel result = _questionnaireService.GetQuestionnaireById(nr_questionnaireid);
            return Ok(_objectConverter.Map<QuestionnaireResponse>(result));
        }


        [HttpGet]
        [Route("{nr_questionnaireid}/QuestionList")]
        public IActionResult GetQuestionnaireQuestionList([FromRoute] int nr_questionnaireid)
        {
            var result = _questionnaireService.GetQuestionnaireQuestionsById(nr_questionnaireid);
            return Ok(_objectConverter.Map<IList<QuestionResponse>>(result));
        }
    }
}