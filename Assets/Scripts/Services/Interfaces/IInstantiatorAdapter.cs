using System.Runtime.Remoting;

namespace Arkham.Services
{
    public interface IInstantiatorAdapter
    {
        T CreateInstance<T>(string typeName);
    }
}
