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
            Container.Bind<CardVisibilityInteractor>().AsSingle();
            Container.BindInterfacesTo<DoubleClickDetector>().AsSingle();
            Container.BindInterfacesTo<DataContext>().AsSingle();
            Container.BindInterfacesTo<DataMapper>().AsSingle();

            /*** Controllers ***/
            Container.Bind(x => x.AllNonAbstractClasses()
           .InNamespace("Arkham").WithSuffix("Controller")).AsCached();

            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
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
            Container.Bind<SelectScenarioUseCase>().AsSingle();
            Container.Bind<AddCardUseCase>().AsSingle();
            Container.Bind<RemoveCardUseCase>().AsSingle();
            Container.Bind<SelectInvestigatorUseCase>().AsSingle();
            Container.Bind<ChangeInvestigatorUseCase>().AsSingle();
            Container.Bind<AddInvestigatorUseCase>().AsSingle();
            Container.Bind<RemoveInvestigatorUseCase>().AsSingle();
            Container.Bind<StartGameUseCase>().AsSingle();

            /*** Interactors ***/
            Container.Bind<CardSelectionInteractor>().AsSingle();
            Container.Bind<InvestigatorSelectionInteractor>().AsSingle();

            /*** Resources ***/
            Container.Bind<CampaignStateSO>().FromScriptableObjectResource(gamefiles.CAMPAIGNS_STATES).AsSingle();

            /*** Factories ***/
            Container.BindInterfacesTo<NameConventionFactory>().AsSingle();
        }
    }
}
