using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servico_gama_ulife.ViewModels
{
    public class AuthResponse
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Role { get; set; }
        public string Token { get; set; }
    }
}
