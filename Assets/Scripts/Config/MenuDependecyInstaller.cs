using Arkham.Adapter;
using Arkham.Model;
using Arkham.Services;
using Arkham.Views;
using Zenject;

namespace Arkham.Config
{
    public class MenuDependecyInstaller : Installer<MenuDependecyInstaller>
    {
        [Inject] private readonly GameFiles gamefiles;

        public override void InstallBindings()
        {
            /*** Services ***/
            Container.BindInterfacesTo<ScreenResolutionAutoDetect>().AsSingle();
            Container.Bind<CardVisibilityService>().AsSingle();
            Container.BindInterfacesTo<DoubleClickDetector>().AsSingle();
            Container.BindInterfacesTo<DataContext>().AsSingle();
            Container.BindInterfacesTo<DataMapper>().AsSingle();

            /*** Controllers ***/
            Container.Bind(x => x.AllNonAbstractClasses()
           .InNamespace("Arkham").WithSuffix("Controller")).AsCached();

            Container.Bind(x => x.AllInterfaces()).To(x => x.AllInterfaces()
           .InNamespace("Arkham").WithSuffix("Controller")).AsCached();

            /*** Managers ***/
            Container.Bind(x => x.AllNonAbstractClasses()
           .InNamespace("Arkham").WithSuffix("Manager")).AsSingle();

            /*** Presenters ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham").WithSuffix("Presenter")).AsCached();

            Container.Bind(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham").WithSuffix("Presenter")).AsCached();

            /*** Adapters ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham").WithSuffix("Adapter")).AsSingle();

            /*** Repositories***/
            Container.Bind<CardRepository>().AsSingle();
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
            Container.Bind<StartGameUseCase>().AsSingle();
            Container.Bind<UnlockCardEventDomain>().AsSingle();

            /*** Interactors ***/
            Container.Bind<CardSelectionFiler>().AsSingle();
            Container.Bind<InvestigatorSelectionFilter>().AsSingle();

            /*** Resources ***/
            Container.Bind<CampaignStateSO>().FromScriptableObjectResource(gamefiles.CAMPAIGNS_STATES).AsSingle();



            /*** Factories ***/
            Container.BindInterfacesTo<NameConventionFactory>().AsSingle();
        }
    }
}
