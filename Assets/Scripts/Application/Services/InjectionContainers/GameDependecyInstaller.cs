using Zenject;

namespace Arkham.Application
{
    public class GameDependecyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameFiles>().AsSingle();

            MenuDependecyInstaller.Install(Container);
        }
    }
}
