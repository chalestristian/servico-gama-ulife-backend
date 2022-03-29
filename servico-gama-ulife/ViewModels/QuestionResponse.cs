using System;
using System.Collections.Generic;

namespace servico_gama_ulife.ViewModels
{
    public class QuestionResponse
    {
        public int Nr_questionid { get; set; }
        public string Ds_question { get; set; }
        public List<AlternativesResponse> Alternatives { get; set; }
    }
}
