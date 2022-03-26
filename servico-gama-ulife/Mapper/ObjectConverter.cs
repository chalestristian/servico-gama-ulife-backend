using AutoMapper;

namespace servico_gama_ulife.Mapper
{
    public class ObjectConverter : IObjectConverter
    {
        private readonly IMapper _mapper;

        public ObjectConverter()
        {
            _mapper = AutoMapperConfig.RegisterMapping().CreateMapper();
        }

        public T Map<T>(object source)
        {
            T model = _mapper.Map<T>(source);

            return model;
        }
    }
}
