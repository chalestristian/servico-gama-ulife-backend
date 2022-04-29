using AutoMapper; 
using servico_gama_ulife.Model;
using servico_gama_ulife.Response;
using servico_gama_ulife.ViewModels;

namespace servico_gama_ulife.Mapper.Profiles
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            CreateMap<UserModel, UserResponse>().ReverseMap();
            CreateMap<QuestionnaireModel, QuestionnaireResponse>().ReverseMap();
            CreateMap<QuestionModel, QuestionResponse>().ReverseMap();
            CreateMap<AlternativesModel, AlternativesResponse>().ReverseMap();
            CreateMap<UserEvaluationModel, UserEvaluationResponse>().ReverseMap();
            CreateMap<EvaluationModel, EvaluationResponse>().ReverseMap();

        }
    }
}
