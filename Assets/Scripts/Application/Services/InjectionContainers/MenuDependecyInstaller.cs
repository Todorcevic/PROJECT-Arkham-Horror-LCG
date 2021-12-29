using Zenject;

namespace Arkham.Application.MainMenu
{
    public class MenuDependecyInstaller : Installer<MenuDependecyInstaller>
    {
        [Inject] private readonly GameFiles gamefiles;

        public override void InstallBindings()
        {
            /*******************************************************************************/
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
            .InNamespace("Arkham").WithSuffix("Presenter")).AsSingle();

            /*** Use Cases ***/
            Container.Bind(x => x.AllNonAbstractClasses()
            .InNamespace("Arkham").WithSuffix("UseCase")).AsSingle();

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

            /*** Resources ***/
            Container.Bind<CampaignStateSO>().FromScriptableObjectResource(gamefiles.CAMPAIGNS_STATES).AsSingle();
        }
    }
}
