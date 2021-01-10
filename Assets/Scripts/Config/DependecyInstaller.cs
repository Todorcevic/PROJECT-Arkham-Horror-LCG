using UnityEngine;
using System.Collections.Generic;
using Zenject;
using Arkham.Adapters;
using Arkham.Model;
using Arkham.Services;
using Arkham.Scenarios;
using Arkham.UI;
using Arkham.Factories;
using Arkham.Investigators;
using System.Linq;
using Sirenix.OdinInspector;

namespace Arkham.Config
{
    public class DependecyInstaller : MonoInstaller
    {
        [Title("CAMPAIGN STATES")]
        [SerializeField] private List<CampaignState> campaignStates;

        //[Title("CARD PREFABS")]
        //[SerializeField] private CardVComponent cardVPrefab;
        //[SerializeField] private CardHComponent cardHPrefab;
        //[SerializeField] private CardRowComponent cardRow;

        //[Title("CARD IMAGES")]
        //[SerializeField] private List<Sprite> cardImagesEN;
        //[SerializeField] private List<Sprite> cardImagesES;

        public override void InstallBindings()
        {
            Container.Bind<GameFiles>().AsSingle();
            Container.Bind<GameData>().AsSingle();
            Container.Bind<PlayerData>().AsSingle();

            Container.Bind<IResolutionSet>().To<ScreenResolutionAutoDetect>().AsSingle();
            Container.Bind<IDataCardsLoader>().To<FileCardLoader>().AsSingle();
            Container.Bind<ISerializer>().To<JsonNewtonsoftAdapter>().AsSingle();
            Container.Bind<IScreenResolutionAdapter>().To<ScreenResolutionAdapter>().AsSingle();
            Container.Bind<IFileAdapter>().To<FileAdapter>().AsSingle();
            Container.Bind<IInstanceAdapter>().To<InstantiatorAdapter>().AsSingle();
            Container.Bind<IScenarioLoader>().To<ScenarioLoader>().AsSingle();
            Container.Bind<ILoadSaveProgress>().To<PlayerProgressIO>().AsSingle();
            Container.Bind<ICardFactory>().To<CardFactory>().AsSingle();

            Container.BindInstance(campaignStates.ToDictionary(campaign => campaign.Id)).AsSingle();
        }
    }
}
