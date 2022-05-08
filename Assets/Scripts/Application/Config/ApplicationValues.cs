using System.IO;
using Zenject;

namespace Arkham.Application
{
    public class ApplicationValues
    {
        [Inject] private readonly GameFiles gameFiles;

        /*******************************************************************/
        public bool DependenciesLoaded { get; set; }
        public bool IsContinuosGame { get; set; }
        public bool CanContinue => File.Exists(gameFiles.PlayerProgressFilePath);
    }
}
