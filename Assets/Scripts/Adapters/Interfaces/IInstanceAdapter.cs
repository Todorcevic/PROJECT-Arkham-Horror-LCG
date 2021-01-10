using System.Runtime.Remoting;

namespace Arkham.Adapters
{
    public interface IInstanceAdapter
    {
        T CreateInstance<T>(string typeName);
    }
}
