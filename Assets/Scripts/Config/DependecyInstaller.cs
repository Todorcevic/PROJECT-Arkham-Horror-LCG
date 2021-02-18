using Zenject;
using Arkham.Adapters;
using Arkham.Repositories;
using Arkham.Services;
using Arkham.Scenarios;
using Arkham.Factories;
using Arkham.Controllers;
using Arkham.Presenters;
using Arkham.Iterators;

namespace Arkham.Config
{
    public class DependecyInstaller : Installer<DependecyInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameFiles>().AsSingle();
            Container.BindInterfacesTo<Repositories.Repositories>().AsSingle();
            Container.BindInterfacesTo<CardRepository>().AsSingle();

            Container.Bind<IDoubleClickDetector>().To<DoubleClickDetector>().AsSingle();
            Container.Bind<IResolutionSet>().To<ScreenResolutionAutoDetect>().AsSingle();
            Container.Bind<ISerializer>().To<JsonNewtonsoftAdapter>().AsSingle();
            Container.Bind<IScreenResolutionAdapter>().To<ScreenResolutionAdapter>().AsSingle();
            Container.Bind<IFileAdapter>().To<FileAdapter>().AsSingle();
            Container.Bind<IInstanceAdapter>().To<InstantiatorAdapter>().AsSingle();
            Container.Bind<IScenarioLoader>().To<ScenarioLoader>().AsSingle();
            Container.Bind<ICardFactory>().To<CardFactory>().AsSingle();
            Container.Bind<IRepositoriesIO>().To<RepositoriesIO>().AsSingle();

            /** Controllers **/
            Container.BindInterfacesTo<SelectorController>().AsSingle();
            Container.BindInterfacesTo<CampaignController>().AsSingle();

            /** Presenters **/
            Container.BindInterfacesTo<SelectorPresenter>().AsSingle();
            Container.BindInterfacesTo<CampaignPresenter>().AsSingle();

            /** Interactors **/
            Container.BindInterfacesTo<InvestigatorsSelectedInteractor>().AsSingle();
            Container.BindInterfacesTo<CampaignInteractor>().AsSingle();

            /** Factories **/
            Container.Bind<ICampaignFactory>().To<CampaignFactory>().AsSingle();
            Container.Bind<ISelectorFactory>().To<SelectorFactory>().AsSingle();
        }
    }
}
