using System;

namespace servico_gama_ulife.Model
{
    public class UserAuthenticationModel
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        internal bool Any()
        {
            throw new NotImplementedException();
        }
    }
}
