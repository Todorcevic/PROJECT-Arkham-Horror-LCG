using Zenject;
using UnityEngine;
using System.Collections.Generic;
using Arkham.Application.MainMenu;
using Arkham.Application.GamePlay;
using UnityEngine.SceneManagement;


namespace Arkham.Application
{
    public enum InstancesInjected { allCardsEN }

    public class MainDependecyInstaller : MonoInstaller
    {
        [SerializeField] private List<Sprite> allCardsEN;

        public override void InstallBindings()
        {
            Container.Bind<GameFiles>().AsSingle();
            Container.BindInstance(allCardsEN).WithId(InstancesInjected.allCardsEN);

            if (SceneManager.GetSceneByBuildIndex(0) == SceneManager.GetActiveScene()) MenuDependecyInstaller.Install(Container);
            if (SceneManager.GetSceneByBuildIndex(1) == SceneManager.GetActiveScene()) GameDependecyInstaller.Install(Container);
        }
    }
}
