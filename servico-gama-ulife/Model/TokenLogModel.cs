using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servico_gama_ulife.Model
{
    public class TokenLogModel
    {
        public int Nr_tokenlogid { get; set; }
        public int Nr_userid { get; set; }
        public string Ds_token { get; set; }
        public DateTime Dt_creationdate { get; set; }
        public DateTime Dt_expirationdate { get; set; }
    }
}
