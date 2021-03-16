using Zenject;
using Arkham.Repositories;
using Arkham.Services;
using Arkham.Scenarios;
using Arkham.Factories;
using Arkham.Presenters;
using Arkham.Interactors;
using Arkham.EventData;
using Arkham.Entities;

namespace Arkham.Config
{
    public class DependecyInstaller : Installer<DependecyInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameFiles>().AsSingle();
            Container.BindInterfacesAndSelfTo<Repository>().AsSingle();

            /*** Services ***/
            Container.BindInterfacesTo<ScreenResolutionAutoDetect>().AsSingle();
            Container.BindInterfacesTo<DataPersistence>().AsSingle();
            Container.Bind<IFileAdapter>().To<FileAdapter>().AsSingle();
            Container.Bind<IScreenResolutionAdapter>().To<ScreenResolutionAdapter>().AsSingle();
            Container.Bind<IInstantiatorAdapter>().To<NameConventionInstantiator>().AsSingle();
            Container.Bind<ISerializer>().To<JsonNewtonsoftAdapter>().AsSingle();
            Container.Bind<IDoubleClickDetector>().To<DoubleClickDetector>().AsSingle();
            Container.Bind<IScenarioLoader>().To<ScenarioLoader>().AsSingle();

            /*** Presenters ***/
            Container.BindInterfacesTo<CampaignPresenter>().AsSingle();
            Container.BindInterfacesTo<InvestigatorSelectorPresenter>().AsSingle();
            Container.BindInterfacesTo<CardSelectorPresenter>().AsSingle();
            Container.BindInterfacesTo<InvestigatorCardPresenter>().AsSingle();
            Container.BindInterfacesTo<DeckCardPresenter>().AsSingle();
            Container.BindInterfacesTo<InvestigatorAvatarPresenter>().AsSingle();
            Container.BindInterfacesTo<CardsQuantityPresenter>().AsSingle();
            Container.BindInterfacesTo<ContinueButtonPresenter>().AsSingle();

            /*** Interactors ***/
            Container.BindInterfacesTo<CampaignInteractor>().AsSingle();
            Container.BindInterfacesTo<InvestigatorSelectorInteractor>().AsSingle();
            Container.BindInterfacesTo<CardSelectorInteractors>().AsSingle();
            Container.BindInterfacesTo<CardInfoInteractor>().AsSingle();
            Container.BindInterfacesTo<InvestigatorInfoInteractor>().AsSingle();

            Container.BindInterfacesTo<ClickableCards>().AsSingle();
            Container.BindInterfacesTo<CurrentInvestigator>().AsSingle();

            /*** Factories ***/
            Container.BindInterfacesTo<DeckCardFactory>().AsSingle();
            Container.BindInterfacesTo<InvestigatorCardFactory>().AsSingle();

            /*** Event Data ***/
            Container.BindInterfacesTo<AddInvestigatorEventData>().AsSingle();
            Container.BindInterfacesTo<RemoveInvestigatorEventData>().AsSingle();
            Container.BindInterfacesTo<ChangeInvestigatorEventData>().AsSingle();
            Container.BindInterfacesTo<SelectInvestigatorEventData>().AsSingle();
            Container.BindInterfacesTo<CampaignEventData>().AsSingle();
            Container.BindInterfacesTo<AddCardEventData>().AsSingle();
            Container.BindInterfacesTo<RemoveCardEventData>().AsSingle();
            Container.BindInterfacesTo<StartGameEventData>().AsSingle();
        }
    }
}
