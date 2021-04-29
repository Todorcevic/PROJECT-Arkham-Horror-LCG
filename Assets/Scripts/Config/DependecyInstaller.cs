using Arkham.Model;
using Arkham.Scenarios;
using Arkham.Services;
using Arkham.Views;
using Zenject;

namespace Arkham.Config
{
    public class DependecyInstaller : Installer<DependecyInstaller>
    {
        [Inject] private readonly GameFiles gamefiles;

        public override void InstallBindings()
        {
            /*** Reositories ***/
            Container.Bind<Settings>().AsSingle();
            Container.BindInterfacesAndSelfTo<CardInfoRepository>().AsSingle();
            Container.BindInterfacesAndSelfTo<CampaignRepository>().AsSingle();
            Container.BindInterfacesAndSelfTo<InvestigatorInfoRepository>().AsSingle();
            Container.BindInterfacesAndSelfTo<UnlockCardRepository>().AsSingle();
            Container.BindInterfacesAndSelfTo<InvestigatorSelectorRepository>().AsSingle();

            /*** Event Data ***/
            Container.Bind<CampaignChangeEventDomain>().AsSingle();
            Container.Bind<AddCardEventDomain>().AsSingle();
            Container.Bind<RemoveCardEventDomain>().AsSingle();
            Container.Bind<InvestigatorSelectorEventDomain>().AsSingle();
            Container.Bind<StartGameEventDomain>().AsSingle();
            Container.Bind<UnlockCardEventDomain>().AsSingle();
            Container.Bind<VisibilityChangeEventDomain>().AsSingle();

            /*** Interactors ***/
            Container.Bind<CurrentInvestigatorInteractor>().AsSingle();
            Container.Bind<PlayGameInteractor>().AsSingle();
            Container.Bind<ContinueGameInteractor>().AsSingle();
            Container.Bind<CardSelectorInteractor>().AsSingle();
            Container.Bind<InvestigatorSelectorInteractor>().AsSingle();

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
          .InNamespace("Arkham").WithSuffix("Adapter")).AsSingle();

            /*** Controllers ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
           .InNamespace("Arkham").WithSuffix("Controller")).AsSingle();

            /*** Managers ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
           .InNamespace("Arkham").WithSuffix("Manager")).AsSingle();

            /*** Presenters ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham").WithSuffix("Presenter")).AsSingle();

            /*** Use Cases ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham").WithSuffix("UseCase")).AsSingle();
        }
    }
}
