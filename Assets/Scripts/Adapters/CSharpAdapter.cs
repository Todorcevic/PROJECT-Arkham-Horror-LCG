using System;
using System.IO;
using System.Runtime.Remoting;

namespace Arkham.Adapters
{
    public class CSharpAdapter : IFileAdapter, IInstanceAdapter
    {
        public bool FileExist(string pathFile) => File.Exists(pathFile);

        public ObjectHandle CreateInstance(string typeName) => Activator.CreateInstance(null, typeName);
    }
}
