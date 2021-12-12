using Arkham.Config;
using Arkham.Services;
using Zenject;

namespace Tests
{
    public class TestsInstaller : Installer<TestsInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameFiles>().AsSingle();
        }
    }
}
