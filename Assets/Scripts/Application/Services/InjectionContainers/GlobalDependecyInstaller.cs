using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkham.Application
{
    public enum InstancesInjected { allCardsEN }

    public class GlobalDependecyInstaller : MonoInstaller
    {
        [SerializeField] private List<Sprite> allCardsEN;

        public override void InstallBindings()
        {
            /*** Basics ***/
            Container.Bind<GameFiles>().AsSingle();
            Container.BindInstance(allCardsEN).WithId(InstancesInjected.allCardsEN);

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
