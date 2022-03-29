using System;
using System.Collections.Generic;

namespace servico_gama_ulife.Model
{
    public class QuestionModel
    {
        public int Nr_questionid { get; set; }
        public string Ds_question { get; set; }
        public int Nr_questionnaireId { get; set; }
        public DateTime Dt_CreationDate { get; set; }
        public DateTime? Dt_ModifieldDate { get; set; }
        public List<AlternativesModel> Alternatives { get; set; }
    }
}
