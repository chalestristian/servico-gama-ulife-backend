namespace servico_gama_ulife.Service.Request
{
    public class AddUser
    {
        public int Nr_registry { get; set; }
        public string Nm_user { get; set; }
        public string Ds_password { get; set; }
        public string Ds_email { get; set; }
        public int Ds_usertypeid { get; set; }
    }
}
