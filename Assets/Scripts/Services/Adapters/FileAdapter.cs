using System.IO;

namespace Arkham.Services
{
    public class FileAdapter : IFileAdapter
    {
        public bool FileExist(string pathFile) => File.Exists(pathFile);
    }
}
