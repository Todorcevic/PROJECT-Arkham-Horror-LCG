﻿using Arkham.Application;
using Zenject;

namespace Arkham.Application
{
    public class MenuDependecyInstaller : Installer<MenuDependecyInstaller>
    {
        [Inject] private readonly GameFiles gamefiles;

        public override void InstallBindings()
        {
            /*** Services ***/
            Container.Bind<ScreenResolutionAutoDetect>().AsSingle();
            Container.Bind<DoubleClickDetector>().AsSingle();
            Container.Bind<DataContext>().AsSingle();
            Container.Bind<DataMapper>().AsSingle();

            /*** Controllers ***/
            Container.Bind(x => x.AllNonAbstractClasses()
           .InNamespace("Arkham").WithSuffix("Controller")).AsCached();

            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
           .InNamespace("Arkham").WithSuffix("Controller")).AsCached();

            /*** Managers ***/
            Container.Bind(x => x.AllNonAbstractClasses()
           .InNamespace("Arkham").WithSuffix("Manager")).AsSingle();

            /*** Presenters ***/
            Container.Bind(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham").WithSuffix("Presenter")).AsCached();

            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham").WithSuffix("Presenter")).AsCached();

            /*** Adapters ***/
            Container.Bind(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham").WithSuffix("Adapter")).AsSingle();

            /*** Use Cases ***/
            Container.Bind(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham").WithSuffix("UseCase")).AsSingle();

            /*** Repositories***/
            Container.Bind(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham").WithSuffix("Repository")).AsSingle();

            /*** Interactors ***/
            Container.Bind(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham").WithSuffix("Interactor")).AsSingle();

            /*** Resources ***/
            Container.Bind<CampaignStateSO>().FromScriptableObjectResource(gamefiles.CAMPAIGNS_STATES).AsSingle();

            /*** Factories ***/
            Container.Bind<NameConventionFactory>().AsSingle();
        }
    }
}