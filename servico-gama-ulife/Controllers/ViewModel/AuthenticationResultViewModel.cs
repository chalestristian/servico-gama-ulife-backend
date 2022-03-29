namespace servico_gama_ulife.Controllers.ViewModel
{
    public class AuthenticationResultViewModel
    {
        public string Message { get; set; }
        public string Token { get; set; }
        public AuthenticationResultViewModel(string message, string token)
        {
            Message = message;
            Token = token;
        }
    }
}
