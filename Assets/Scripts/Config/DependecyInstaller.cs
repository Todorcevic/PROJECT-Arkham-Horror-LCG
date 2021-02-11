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
            Container.BindInterfacesAndSelfTo<Repository>().AsSingle();
            Container.BindInterfacesAndSelfTo<CardRepository>().AsSingle();

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
            //Container.Bind(x => x.AllTypes().WithSuffix("Controller").InNamespace("Arkham.Controllers"))
            //    .To(x => x.AllClasses().WithSuffix("Controller").InNamespace("Arkham.Controllers")).AsSingle();

            //Container.Bind(x => x.AllTypes().WithSuffix("Controller").InNamespace("Arkham.Controllers"))
            //    .To(x => x.AllAbstractClasses().WithSuffix("Controllero").InNamespace("Arkham.Controllers")).AsSingle();

            Container.BindInterfacesAndSelfTo<CampaignController>().AsSingle();
            Container.BindInterfacesAndSelfTo<InvestigatorSelectorController>().AsSingle();
            Container.BindInterfacesAndSelfTo<CardInvestigatorController>().AsSingle()
                .WhenInjectedInto<CardInvestigatorView>();
            Container.BindInterfacesAndSelfTo<CardRowController>().AsSingle()
                .WhenInjectedInto<CardRowView>();
            Container.BindInterfacesAndSelfTo<CardDeckController>().AsSingle()
                .WhenInjectedInto<CardDeckView>();

            /** Managers **/
            Container.Bind<ICampaignsManager>().To<CampaignsManager>().AsSingle();
            Container.Bind<IInvestigatorSelectorsManager>().To<InvestigatorSelectorsManager>().AsSingle();
        }
    }
}
