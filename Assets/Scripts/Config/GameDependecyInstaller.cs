using Zenject;

namespace Arkham.Config
{
    public class GameDependecyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            DependecyInstaller.Install(Container);
        }
    }
}
