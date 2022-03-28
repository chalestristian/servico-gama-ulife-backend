using AutoMapper;
using servico_gama_ulife.Mapper.Profiles;

namespace servico_gama_ulife.Mapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMapping(params Profile[] profiles)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToResponseProfile());

            });
        }
    }
}
