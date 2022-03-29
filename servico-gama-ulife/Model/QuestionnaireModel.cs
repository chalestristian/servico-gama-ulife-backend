using System;
using System.Collections.Generic;

namespace servico_gama_ulife.Model
{
    public class QuestionnaireModel
    {
        public int Nr_questionnaireId { get; set; }
        public int Nr_userId { get; set; }
        public string Ds_Questionnaire { get; set; }
        public DateTime Dt_CreationDate { get; set; }
        public DateTime? Dt_ModifieldDate { get; set; }
        public List<QuestionModel> Questions { get; set; }
    }
}
