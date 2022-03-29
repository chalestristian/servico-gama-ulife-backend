using AutoMapper;
using servico_gama_ulife.Model;
using servico_gama_ulife.Response;

namespace servico_gama_ulife.Mapper.Profiles
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            CreateMap<UserModel, UserResponse>().ReverseMap();
        }
    }
}
