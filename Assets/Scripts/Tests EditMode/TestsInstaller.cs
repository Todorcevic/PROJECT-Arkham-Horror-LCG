using Arkham.Application;
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
