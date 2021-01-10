using System;
using System.IO;
using System.Runtime.Remoting;

namespace Arkham.Adapters
{
    public class FileAdapter : IFileAdapter
    {
        public bool FileExist(string pathFile) => File.Exists(pathFile);
    }
}
