using System.Runtime.Remoting;

namespace Arkham.Adapters
{
    public interface IInstanceAdapter
    {
        ObjectHandle CreateInstance(string typeName);
    }
}
