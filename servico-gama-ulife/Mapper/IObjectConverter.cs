namespace servico_gama_ulife.Mapper
{
    public interface IObjectConverter
    {
        T Map<T>(object source);
    }
}
