using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkham
{
    public enum InstancesInjected { allCardsEN }

    public class GlobalDependecyInstaller : MonoInstaller
    {
        [SerializeField] private List<Sprite> allCardsEN;

        private string AssamblyName => GetType().Namespace;

        /*******************************************************************/
        public override void InstallBindings()
        {
            /*** Basics ***/
            Container.Bind<Application.GameFiles>().AsSingle();
            Container.BindInstance(allCardsEN).WithId(InstancesInjected.allCardsEN);

            /*** Services ***/
            Container.Bind(x => x.AllNonAbstractClasses()
            .InNamespace(AssamblyName).WithSuffix("Service")).AsSingle();

            /*** Repositories***/
            Container.Bind(x => x.AllNonAbstractClasses()
            .InNamespace(AssamblyName).WithSuffix("Repository")).AsSingle();

            /*** Interactors ***/
            Container.Bind(x => x.AllNonAbstractClasses()
            .InNamespace(AssamblyName).WithSuffix("Interactor")).AsSingle();
        }
    }
}
