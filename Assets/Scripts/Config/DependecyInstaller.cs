using Zenject;
using Arkham.Adapters;
using Arkham.Repositories;
using Arkham.Services;
using Arkham.Scenarios;
using Arkham.Factories;
using Arkham.Controllers;
using Arkham.Presenters;
using Arkham.Interactors;
using Arkham.Managers;

namespace Arkham.Config
{
    public class DependecyInstaller : Installer<DependecyInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameFiles>().AsSingle();
            Container.BindInterfacesTo<AllRepositories>().AsSingle();

            /** Services **/
            Container.Bind<IFileAdapter>().To<FileAdapter>().AsSingle();
            Container.Bind<IScreenResolutionAdapter>().To<ScreenResolutionAdapter>().AsSingle();
            Container.Bind<IInstantiatorAdapter>().To<NameConventionInstantiator>().AsSingle();
            Container.Bind<ISerializer>().To<JsonNewtonsoftAdapter>().AsSingle();
            Container.Bind<IDoubleClickDetector>().To<DoubleClickDetector>().AsSingle();
            Container.Bind<IResolutionSet>().To<ScreenResolutionAutoDetect>().AsSingle();
            Container.Bind<IScenarioLoader>().To<ScenarioLoader>().AsSingle();
            Container.Bind<IDataPersistence>().To<DataPersistence>().AsSingle();

            /** Controllers **/
            Container.BindInterfacesTo<CampaignController>().AsSingle();
            Container.BindInterfacesTo<SelectorController>().AsSingle();
            Container.BindInterfacesTo<InvestigatorCardController>().AsSingle();

            /** Presenters **/
            Container.BindInterfacesTo<CampaignPresenter>().AsSingle();
            Container.BindInterfacesTo<SelectorPresenter>().AsSingle();
            Container.BindInterfacesTo<InvestigatorCardPresenter>().AsSingle();

            /** Interactors **/
            Container.BindInterfacesTo<CampaignInteractor>().AsSingle();
            Container.BindInterfacesTo<SelectorInteractor>().AsSingle();

            /** Factories **/
            Container.Bind<ICampaignFactory>().To<CampaignFactory>().AsSingle();
            Container.Bind<ISelectorFactory>().To<SelectorFactory>().AsSingle();
            Container.Bind<ICardFactory>().To<CardFactory>().AsSingle();
        }
    }
}
