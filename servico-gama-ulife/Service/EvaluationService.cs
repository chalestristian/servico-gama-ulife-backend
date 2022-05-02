using servico_gama_ulife.Model;
using servico_gama_ulife.Repository.Interface;
using servico_gama_ulife.Service.Interface;
using servico_gama_ulife.Service.Request;
using System;
using System.Collections.Generic;
using System.Linq;

namespace servico_gama_ulife.Service
{
    public class EvaluationService : IEvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public EvaluationService(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public IList<EvaluationModel> GetEvaluation()
        {
            return _evaluationRepository.GetEvaluation();
        }

        public bool SaveGrade(int nr_registry, int nr_userevaluationid,
            SaveGradeModel saveGradeModels)
        {
            float qtdCorrectAnswers = 0;

            var questions = _evaluationRepository.GetQuestionList(nr_registry);

            float qtdQuestions = questions.Select(o => o.Nr_questionid).Distinct().Count();

            var questoesCertas = questions.Where(i => i.Ds_correctanswer).Select(o => o.Nr_alternativesid).ToList();

            qtdCorrectAnswers += (from item in questoesCertas
                                  where saveGradeModels.Answers.Contains(item)
                                  select item).Count();

            float grade = GetAverageGrade(qtdCorrectAnswers, qtdQuestions);
            return _evaluationRepository.SaveGrade(nr_userevaluationid, grade);
        }

        private static float GetAverageGrade(float qtdCorrectAnswers, float quantidadeQuestion)
        {
            return ((qtdCorrectAnswers / quantidadeQuestion) * 10);
        }

        public EvaluationModel GetEvaluationById(int nr_evaluationid)
        {
            var resp = _evaluationRepository.GetEvaluationById(nr_evaluationid);
            return resp;
        }

        public IEnumerable<GetUserEvaluation> GetEvaluationByUserId(int nr_userId)
        {
            var resp = _evaluationRepository.GetEvaluationByUserId(nr_userId);
            return resp;
        }
    }
}



