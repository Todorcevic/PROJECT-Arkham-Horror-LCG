using Zenject;
using Arkham.Repositories;
using Arkham.Services;
using Arkham.Scenarios;
using Arkham.Views;

namespace Arkham.Config
{
    public class DependecyInstaller : Installer<DependecyInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameFiles>().AsSingle();
            Container.BindInterfacesAndSelfTo<Repository>().AsSingle();

            /*** Managers ***/
            Container.BindInterfacesTo<CardsManager>().AsSingle();

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

            /*** Presenters ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham").WithSuffix("Presenter")).AsSingle();

            /*** Interactors ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham.Interactors").WithSuffix("Interactor")).AsSingle();

            /*** Event Data ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham.EventData").WithSuffix("EventData")).AsSingle();
        }
    }
}
