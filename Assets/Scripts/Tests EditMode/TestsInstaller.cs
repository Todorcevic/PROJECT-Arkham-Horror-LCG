using Arkham.Adapters;
using Arkham.Config;
using Arkham.Factories;
using Arkham.Repositories;
using Arkham.Scenarios;
using Arkham.Services;
using Zenject;

namespace Tests
{
    public class TestsInstaller : Installer<TestsInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameFiles>().AsSingle();
            Container.BindInterfacesTo<AllRepositories>().AsSingle();

            Container.Bind<IDoubleClickDetector>().To<DoubleClickDetector>().AsSingle();
            Container.Bind<IResolutionSet>().To<ScreenResolutionAutoDetect>().AsSingle();
            Container.Bind<ISerializer>().To<JsonNewtonsoftAdapter>().AsSingle();
            Container.Bind<IScreenResolutionAdapter>().To<ScreenResolutionAdapter>().AsSingle();
            Container.Bind<IFileAdapter>().To<FileAdapter>().AsSingle();
            Container.Bind<IInstantiatorAdapter>().To<NameConventionInstantiator>().AsSingle();
            Container.Bind<IScenarioLoader>().To<ScenarioLoader>().AsSingle();
            Container.Bind<ICardFactory>().To<CardFactory>().AsSingle();
            Container.Bind<IDataPersistence>().To<DataPersistence>().AsSingle();
        }
    }
}
