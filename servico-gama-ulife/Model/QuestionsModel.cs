using System;
using System.Collections.Generic;

namespace servico_gama_ulife.Model
{
    public class QuestionsModel
    {
        public int Nr_questionid { get; set; }
        public int Nr_alternativesid { get; set; }
        public int Nr_userid { get; set; }
        public bool Ds_correctanswer { get; set; }
        public string Ds_alternatives { get; set; }
        public DateTime Dt_creationdate { get; set; }
        public DateTime Dt_modifieddate { get; set; }

    }
}
