using Zenject;
using Arkham.Repositories;
using Arkham.Services;
using Arkham.Scenarios;
using UnityEngine;
using Arkham.Managers;
using Arkham.Controllers;

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
            Container.BindInterfacesTo<NameConventionInstantiator>().AsSingle();
            Container.BindInterfacesTo<DoubleClickDetector>().AsSingle();
            Container.BindInterfacesTo<ScenarioLoader>().AsSingle();

            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham.Services").WithSuffix("Adapter")).AsSingle();

            /*** Factories ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham.Factories").WithSuffix("Factory")).AsSingle();

            /*** Managers ***/
            //Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            //.InNamespace("Arkham.Managers").WithSuffix("Manager")).AsSingle();

            /*** Controllers ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham.Controllers").WithSuffix("Controller")).AsSingle();

            /*** Presenters ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham.Presenters").WithSuffix("Presenter")).AsSingle();

            /*** Interactors ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham.Interactors").WithSuffix("Interactor")).AsSingle();

            /*** Event Data ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham.EventData").WithSuffix("EventData")).AsSingle();
        }
    }
}
