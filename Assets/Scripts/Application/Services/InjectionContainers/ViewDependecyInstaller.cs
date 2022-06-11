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

        private string AssamblyName => GetType().Namespace + "." + assambly;

        /*******************************************************************/
        public override void InstallBindings()
        {
            /*** EventHandler ***/
            Container.Bind(x => x.AllInterfaces()).To(x => x.AllNonAbstractClasses()
           .InNamespace(AssamblyName).WithSuffix("EventHandler")).AsSingle();

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
