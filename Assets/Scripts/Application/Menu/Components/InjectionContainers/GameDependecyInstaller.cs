using Zenject;
using UnityEngine;
using System.Collections.Generic;

namespace Arkham.Application
{
    public enum InstancesInjected
    {
        allCardsEN
    }

    public class GameDependecyInstaller : MonoInstaller
    {
        [SerializeField] private List<Sprite> allCardsEN;

        public override void InstallBindings()
        {
            Container.Bind<GameFiles>().AsSingle();
            Container.BindInstance(allCardsEN).WithId(InstancesInjected.allCardsEN);
            MenuDependecyInstaller.Install(Container);
        }
    }
}
