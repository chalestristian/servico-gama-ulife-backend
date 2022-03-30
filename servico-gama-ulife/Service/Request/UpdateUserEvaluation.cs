using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servico_gama_ulife.Service.Request
{
    public class UpdateUserEvaluation
    {
        public int Nr_userid { get; set; }
        public int Nr_userevaluationid { get; set; }
        public double Dr_grade { get; set; }
        public bool Ds_hasdone { get; set; }
    }
}
