using UnityEngine;
using System.Collections.Generic;
using Zenject;
using Arkham.Adapters;
using Arkham.Model;
using Arkham.Services;
using Arkham.Scenarios;
using Arkham.UI;
using Arkham.Factories;
using System.Linq;
using Sirenix.OdinInspector;

namespace Arkham.Config
{
    public class DependecyInstaller : MonoInstaller
    {
        [Title("CAMPAIGN STATES")]
        [SerializeField] private List<CampaignState> campaignStates;
        private Dictionary<string, CampaignState> campaignsStateDictionary;

        [Title("CARD PREFABS")]
        [SerializeField] private CardVComponent cardVPrefab;
        [SerializeField] private CardHComponent cardHPrefab;
        [SerializeField] private CardRowComponent cardRow;

        public override void InstallBindings()
        {
            Container.Bind<GameFiles>().AsSingle();
            Container.Bind<GameData>().AsSingle();
            Container.Bind<PlayerData>().AsSingle();

            Container.Bind<IResolutionSet>().To<ScreenResolutionAutoDetect>().AsSingle();
            Container.Bind<IDataCardsLoader>().To<FileCardLoader>().AsSingle();
            Container.Bind<ISerializer>().To<JsonNewtonsoftAdapter>().AsSingle();
            Container.Bind<IScreenResolutionAdapter>().To<ScreenResolutionAdapter>().AsSingle();
            Container.Bind<IFileAdapter>().To<CSharpAdapter>().AsSingle();
            Container.Bind<IInstanceAdapter>().To<CSharpAdapter>().AsSingle();
            Container.Bind<IScenarioLoader>().To<ScenarioLoader>().AsSingle();
            Container.Bind<ILoadSaveProgress>().To<PlayerProgressIO>().AsSingle();
            Container.Bind<ICardFactory>().To<CardFactory>().AsSingle();

            Container.BindInstance(campaignsStateDictionary);
            Container.Bind<CardVComponent>().FromNewComponentOnNewPrefab(cardVPrefab);
            Container.Bind<CardHComponent>().FromNewComponentOnNewPrefab(cardHPrefab);
            Container.Bind<CardRowComponent>().FromNewComponentOnNewPrefab(cardRow);
        }

        public void CampaignStateToDictionary() =>
            campaignsStateDictionary = campaignStates.ToDictionary(campaign => campaign.Id);
    }
}
