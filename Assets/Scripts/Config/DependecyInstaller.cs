using Arkham.Model;
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
            /*** Repositories***/
            Container.Bind<CardRepository>().AsSingle();
            Container.Bind<Settings>().AsSingle();
            Container.Bind<CampaignRepository>().AsSingle();
            Container.Bind<InvestigatorRepository>().AsSingle();
            Container.Bind<Selector>().AsSingle();
            Container.Bind<UnlockCardsRepository>().AsSingle();

            /*** Event Data ***/
            Container.Bind<CampaignEventDomain>().AsSingle();
            Container.Bind<ScenarioEventDomain>().AsSingle();
            Container.Bind<AddCardEventDomain>().AsSingle();
            Container.Bind<RemoveCardEventDomain>().AsSingle();
            Container.Bind<SelectInvestigatorEventDomain>().AsSingle();
            Container.Bind<ChangeInvestigatorEventDomain>().AsSingle();
            Container.Bind<AddInvestigatorEventDomain>().AsSingle();
            Container.Bind<RemoveInvestigatorEventDomain>().AsSingle();
            Container.Bind<StartGameEventDomain>().AsSingle();
            Container.Bind<UnlockCardEventDomain>().AsSingle();
            Container.Bind<VisibilityEventDomain>().AsSingle();
            Container.Bind<SearchTextEventDomain>().AsSingle();

            /*** Interactors ***/
            Container.Bind<CardState>().AsSingle();
            Container.Bind<InvestigatorState>().AsSingle();

            /*** Resources ***/
            Container.Bind<CampaignStateSO>().FromScriptableObjectResource(gamefiles.CAMPAIGNS_STATES).AsSingle();

            /*** Services ***/
            Container.BindInterfacesTo<ScreenResolutionAutoDetect>().AsSingle();

            Container.BindInterfacesTo<DoubleClickDetector>().AsSingle();
            Container.BindInterfacesTo<DataContext>().AsSingle();
            Container.BindInterfacesTo<DataMapper>().AsSingle();

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

            /*** Factories ***/
            Container.BindInterfacesTo<CampaignStateFactory>().AsSingle();
            Container.BindInterfacesTo<NameConventionFactory>().AsSingle();
        }
    }
}
