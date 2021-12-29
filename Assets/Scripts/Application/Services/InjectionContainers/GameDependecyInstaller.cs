using Zenject;

namespace Arkham.Application.GamePlay
{
    public class GameDependecyInstaller : Installer<GameDependecyInstaller>
    {
        public override void InstallBindings()
        {
            /*******************************************************************************/
            /*** Controllers ***/
            Container.Bind(x => x.AllNonAbstractClasses()
           .InNamespace("Arkham.Application.GamePlay").WithSuffix("Controller")).AsCached();

            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
           .InNamespace("Arkham.Application.GamePlay").WithSuffix("Controller")).AsCached();

            /*** Managers ***/
            Container.Bind(x => x.AllNonAbstractClasses()
           .InNamespace("Arkham.Application.GamePlay").WithSuffix("Manager")).AsSingle();

            /*** Presenters ***/
            Container.Bind(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham.Application.GamePlay").WithSuffix("Presenter")).AsSingle();

            /*** Use Cases ***/
            Container.Bind(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham.Application.GamePlay").WithSuffix("UseCase")).AsSingle();

            /*******************************************************************************/
            /*** Services ***/
            Container.Bind(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham").WithSuffix("Service")).AsSingle();

            /*** Repositories***/
            Container.Bind(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham").WithSuffix("Repository")).AsSingle();

            /*** Interactors ***/
            Container.Bind(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham").WithSuffix("Interactor")).AsSingle();
        }
    }
}
