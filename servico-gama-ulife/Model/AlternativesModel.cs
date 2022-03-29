using System;

namespace servico_gama_ulife.Model
{
    public class AlternativesModel
    {
        public int Nr_alternativesid { get; set; }
        public string Ds_alternatives { get; set; }
        public int Nr_userid { get; set; }
        public bool Ds_correctanswer { get; set; }
        public DateTime Dt_CreationDate { get; set; }
        public DateTime? Dt_ModifieldDate { get; set; }
    }
}
