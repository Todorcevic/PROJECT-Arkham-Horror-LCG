using Arkham.Config;
using Arkham.Model;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Services
{
    public class DataPersistence : IInitializable, IDataContext
    {
        [Inject] private readonly GameFiles gameFiles;
        [Inject] private readonly Settings settings;
        [Inject] private readonly ISerializer serializer;
        [Inject] private readonly IPlayerPrefsAdapter playerPrefs;
        [Inject] private readonly IInstantiatorAdapter instantiator;
        [Inject] private readonly StartGameEventDomain gameStartedEvent;
        [Inject] private readonly CardInfoRepository cardInfo;
        [Inject] private readonly CampaignRepository campaignData;
        [Inject] private readonly InvestigatorInfoRepository investigatorData;
        [Inject] private readonly InvestigatorSelectorRepository selectorData;
        [Inject] private readonly UnlockCardRepository unlockCardData;

        /*******************************************************************/
        void IInitializable.Initialize() => gameStartedEvent.GameStarted += LoadProgress;

        public void LoadDataCards() =>
            cardInfo.CardInfoList = serializer.CreateDataFromResources<List<CardInfo>>(gameFiles.CardsDataFilePath);

        public void LoadSettings() => settings.AreCardsVisible = playerPrefs.LoadCardsVisibility();

        public void SaveProgress() => serializer.SaveFileFromData(CreateDTO(), gameFiles.PlayerProgressFilePath);

        private Repository CreateDTO() => new Repository()
        {
            CurrentScenario = campaignData.CurrentScenario,
            CampaignsList = campaignData.CampaignsList,
            InvestigatorsList = investigatorData.InvestigatorsList,
            InvestigatorsSelectedList = selectorData.InvestigatorsSelectedList,
            UnlockCards = unlockCardData.UnlockCards
        };

        private void LoadProgress(StartGame gameType)
        {
            Repository repositoryDTO = gameType == StartGame.New ? LoadNewGame() : LoadContinue();
            CreateRepositories(repositoryDTO);
            LoadDependency();
        }

        private Repository LoadNewGame() => serializer.CreateDataFromResources<Repository>(gameFiles.PlayerProgressDefaultFilePath);

        private Repository LoadContinue() => serializer.CreateDataFromFile<Repository>(gameFiles.PlayerProgressFilePath);

        private void CreateRepositories(Repository repositoryDTO)
        {
            campaignData.CurrentScenario = repositoryDTO.CurrentScenario;
            campaignData.CampaignsList = repositoryDTO.CampaignsList;
            investigatorData.InvestigatorsList = repositoryDTO.InvestigatorsList;
            selectorData.InvestigatorsSelectedList = repositoryDTO.InvestigatorsSelectedList;
            unlockCardData.UnlockCards = repositoryDTO.UnlockCards;
        }

        private void LoadDependency()
        {
            foreach (InvestigatorInfo investigator in investigatorData.InvestigatorsList)
            {
                investigator.Info = cardInfo.Get(investigator.Id);
                investigator.DeckBuilding = instantiator.CreateInstance<DeckBuildingRules>(investigator.Id);
            }
        }
    }
}
