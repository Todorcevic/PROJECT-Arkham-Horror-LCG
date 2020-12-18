using Zenject;

namespace Arkham.UI
{
    public class DependecyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameData>().AsSingle();
            Container.Bind<IResolutionSet>().To<DefaultResolutionSet>().AsSingle();
            Container.Bind<IDataCardsLoader>().To<FileCardLoader>().AsSingle();
            Container.Bind<ISerializer>().To<JsonNewtonsoftAdapter>().AsSingle();
        }
    }
}
