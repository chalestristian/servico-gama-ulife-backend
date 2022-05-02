using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servico_gama_ulife.Service.Request
{
    public class GetUserEvaluation
    {
        public string nm_user { get; set; }
        public string nm_evaluation { get; set; }
        public string nm_questionnaire { get; set; }
        public string ds_questionnaire { get; set; }
        public int nr_questionnaireid { get; set; }
        public int nr_userevaluationid { get; set; }
    }
}
