using System;

namespace servico_gama_ulife.Model
{
    public class UserEvaluationModel
    {
        public int Nr_userevaluationid { get; set; }
        public int Nr_userid { get; set; }
        public int Nr_evaluationid { get; set; }
        public double Nr_grade { get; set; }
        public bool Ds_hasdone { get; set; }
        public DateTime Dt_creationdate { get; set; }
        public DateTime Dt_modifieddate { get; set; }
    }
}