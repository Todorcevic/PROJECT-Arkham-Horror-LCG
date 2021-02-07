using Zenject;
using Arkham.Adapters;
using Arkham.Repositories;
using Arkham.Services;
using Arkham.Scenarios;
using Arkham.Views;
using Arkham.Factories;
using Arkham.Presenters;
using Arkham.Controllers;
using Arkham.Models;
using Arkham.UseCases;
using Arkham.Managers;

namespace Arkham.Config
{
    public class DependecyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameFiles>().AsSingle();
            Container.Bind<CardRepository>().AsSingle();
            Container.Bind<Repository>().AsSingle();

            Container.Bind<IDoubleClick>().To<DoubleClick>().AsSingle();
            Container.Bind<IResolutionSet>().To<ScreenResolutionAutoDetect>().AsSingle();
            Container.Bind<ISerializer>().To<JsonNewtonsoftAdapter>().AsSingle();
            Container.Bind<IScreenResolutionAdapter>().To<ScreenResolutionAdapter>().AsSingle();
            Container.Bind<IFileAdapter>().To<FileAdapter>().AsSingle();
            Container.Bind<IInstanceAdapter>().To<InstantiatorAdapter>().AsSingle();
            Container.Bind<IScenarioLoader>().To<ScenarioLoader>().AsSingle();
            Container.Bind<ICardFactory>().To<CardFactory>().AsSingle();
            Container.Bind<IContext>().To<ContextJson>().AsSingle();

            /** Presenters **/
            Container.Bind<IPresenter<IInvestigatorSelectorView>>().To<InvestigatorSelectorPresenter>().AsSingle();
            Container.Bind<IPresenter<IInvestigatorSelectorManager>>().To<InvestigatorSelectorManagerPresenter>().AsSingle();

            /** Controllers **/
            Container.Bind<ISemiFullController<ICampaignView>>().To<CampaignController>().AsSingle();
            Container.Bind<IFullController<IInvestigatorSelectorView>>().To<InvestigatorSelectorController>().AsSingle();
            Container.Bind<IHoverController<ICardView>>().To<CardController>().AsSingle();
            Container.Bind<IDoubleClickController<ICardInvestigatorView>>().To<CardInvestigatorController>().AsSingle();

            /** Use Cases ***/
            Container.Bind<IInvestigatorSelector>().To<InvestigatorSelector>().AsSingle();
        }
    }
}
