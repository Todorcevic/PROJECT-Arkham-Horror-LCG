using Zenject;
using Arkham.Services;
using Arkham.Scenarios;
using Arkham.Views;
using Arkham.Repositories;

namespace Arkham.Config
{
    public class DependecyInstaller : Installer<DependecyInstaller>
    {
        [Inject] private readonly GameFiles gamefiles;

        public override void InstallBindings()
        {
            Container.Bind<Settings>().AsSingle();

            /*** Reositories ***/
            //  Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            //.InNamespace("Arkham.Repositories").WithSuffix("Repository")).AsSingle();

            Container.BindInterfacesTo<CardInfoRepository>().AsSingle();
            Container.BindInterfacesTo<CampaignRepository>().AsSingle();
            Container.BindInterfacesTo<InvestigatorInfoRepository>().AsSingle();
            Container.BindInterfacesTo<UnlockCardsRepository>().AsSingle();
            Container.BindInterfacesTo<InvestigatorSelectorRepository>().AsSingle();

            /*** Resources ***/
            Container.Bind<CampaignState>().FromScriptableObjectResource(gamefiles.CAMPAIGNS_STATES).AsSingle();

            /*** Services ***/
            Container.BindInterfacesTo<ScreenResolutionAutoDetect>().AsSingle();
            Container.BindInterfacesTo<DataPersistence>().AsSingle();
            Container.BindInterfacesTo<NameConventionInstantiator>().AsSingle();
            Container.BindInterfacesTo<DoubleClickDetector>().AsSingle();
            Container.BindInterfacesTo<ScenarioLoader>().AsSingle();

            /*** Adapters ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
          .InNamespace("Arkham.Services").WithSuffix("Adapter")).AsSingle();

            /*** Controllers ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
           .InNamespace("Arkham").WithSuffix("Controller")).AsSingle();

            /*** Managers ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
           .InNamespace("Arkham").WithSuffix("Manager")).AsSingle();

            /*** Presenters ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham").WithSuffix("Presenter")).AsSingle();

            /*** Interactors ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham.Interactors").WithSuffix("Interactor")).AsSingle();

            /*** Event Data ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham.EventData").WithSuffix("EventData")).AsSingle();

            /*** Use Cases ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham").WithSuffix("UseCase")).AsSingle();
        }
    }
}
