using Arkham.Application.MainMenu;
using UnityEngine;
using Zenject;

namespace Arkham.Application
{
    public class ViewDependecyInstaller : MonoInstaller
    {
        private enum Assambly { MainMenu, GamePlay }
        [Inject] private readonly GameFiles gamefiles;
        [SerializeField] private Assambly assambly;

        private string AssamblyName => "Arkham.Application." + assambly;

        public override void InstallBindings()
        {
            /*** Controllers ***/
            Container.Bind(x => x.AllNonAbstractClasses()
           .InNamespace(AssamblyName).WithSuffix("Controller")).AsCached();

            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
           .InNamespace(AssamblyName).WithSuffix("Controller")).AsCached();

            /*** Managers ***/
            Container.Bind(x => x.AllNonAbstractClasses()
           .InNamespace(AssamblyName).WithSuffix("Manager")).AsSingle();

            /*** Presenters ***/
            Container.Bind(x => x.AllNonAbstractClasses()
            .InNamespace(AssamblyName).WithSuffix("Presenter")).AsSingle();

            /*** Use Cases ***/
            Container.Bind(x => x.AllNonAbstractClasses()
            .InNamespace(AssamblyName).WithSuffix("UseCase")).AsSingle();

            /*** Resources ***/
            Container.Bind<CampaignStateSO>().FromScriptableObjectResource(gamefiles.CAMPAIGNS_STATES).AsSingle();
        }
    }
}
