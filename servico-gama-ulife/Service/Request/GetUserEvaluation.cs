using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servico_gama_ulife.Service.Request
{
    public class GetUserEvaluation
    {
        public string Nm_user { get; set; }
        public string Nm_evaluation { get; set; }
        public string Nm_questionnaire { get; set; }
        public string Ds_questionnaire { get; set; }
        public decimal? Dr_grade { get; set; }
        public int Nr_questionnaireid { get; set; }
        public int Nr_userevaluationid { get; set; }
    }
}
