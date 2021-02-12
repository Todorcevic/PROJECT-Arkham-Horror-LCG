using Zenject;
using Arkham.Adapters;
using Arkham.Repositories;
using Arkham.Services;
using Arkham.Scenarios;
using Arkham.Views;
using Arkham.Factories;
using Arkham.Controllers;
using Arkham.Models;
using Arkham.Managers;

namespace Arkham.Config
{
    public class DependecyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameFiles>().AsSingle();
            Container.BindInterfacesTo<Repository>().AsSingle();
            Container.BindInterfacesTo<CardRepository>().AsSingle();

            Container.Bind<IDoubleClickDetector>().To<DoubleClickDetector>().AsSingle();
            Container.Bind<IResolutionSet>().To<ScreenResolutionAutoDetect>().AsSingle();
            Container.Bind<ISerializer>().To<JsonNewtonsoftAdapter>().AsSingle();
            Container.Bind<IScreenResolutionAdapter>().To<ScreenResolutionAdapter>().AsSingle();
            Container.Bind<IFileAdapter>().To<FileAdapter>().AsSingle();
            Container.Bind<IInstanceAdapter>().To<InstantiatorAdapter>().AsSingle();
            Container.Bind<IScenarioLoader>().To<ScenarioLoader>().AsSingle();
            Container.Bind<ICardFactory>().To<CardFactory>().AsSingle();
            Container.Bind<IContext>().To<ContextJson>().AsSingle();

            /** Controllers **/
            Container.Bind<ICampaignController>().To<CampaignController>().AsTransient();
            Container.Bind<IInvestigatorSelectorController>().To<InvestigatorSelectorController>().AsTransient();
            Container.Bind<ICardController>().To<CardInvestigatorController>().AsTransient()
                .WhenInjectedInto<CardInvestigatorView>();

            //Container.BindInterfacesTo<CardInvestigatorController>().AsTransient()
            //    .WhenInjectedInto<CardInvestigatorView>();
            //Container.BindInterfacesTo<CardRowController>().AsTransient()
            //    .WhenInjectedInto<CardRowView>();
            //Container.BindInterfacesTo<CardDeckController>().AsTransient()
            //    .WhenInjectedInto<CardDeckView>();

            /** Managers **/
            Container.Bind<ICampaignsManager>().To<CampaignsManager>().AsSingle();
            Container.Bind<IInvestigatorSelectorsManager>().To<InvestigatorSelectorsManager>().AsSingle();
            Container.BindInterfacesTo<CardsInvestigatorManager>().AsSingle();
            Container.BindInterfacesTo<CardsDeckManager>().AsSingle();

        }
    }
}
