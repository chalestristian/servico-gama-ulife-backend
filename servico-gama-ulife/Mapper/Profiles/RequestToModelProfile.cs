using AutoMapper;
using servico_gama_ulife.Controllers.Request;
using servico_gama_ulife.Model;

namespace servico_gama_ulife.Mapper.Profiles
{
    public class RequestToModelProfile : Profile
    {
        public RequestToModelProfile()
        {
            CreateMap<UserAuthenticationRequest, UserAuthenticationModel>().ReverseMap();
        }
    }
}
