namespace Arkham.Services
{
    public interface IConventionFactory
    {
        T CreateInstance<T>(string typeName);
    }
}
