using Zenject;

namespace Arkham.Config
{
    public class GameDependecyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameFiles>().AsSingle();

            DependecyInstaller.Install(Container);
        }
    }
}
