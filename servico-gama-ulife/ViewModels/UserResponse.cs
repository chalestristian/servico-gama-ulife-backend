using System;

namespace servico_gama_ulife.Response
{
    public class UserResponse
    {
        public int Nr_userid { get; set; }
        public int Nr_registry { get; set; }
        public string Nm_user { get; set; }
        public string Ds_email { get; set; }
        public int Ds_usertypeid { get; set; }
        public DateTime Dt_creationdate { get; set; }
        public DateTime Dt_modifieddate { get; set; }
    }
}
