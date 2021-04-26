using Arkham.Entities;
using Arkham.Config;
using Arkham.Repositories;
using Zenject;
using System.Collections.Generic;

namespace Arkham.Services
{
    public class DataPersistence : IDataPersistence
    {
        [Inject] private readonly GameFiles gameFiles;
        [Inject] private readonly Settings settings;
        [Inject] private readonly ISerializer serializer;
        [Inject] private readonly IPlayerPrefsAdapter playerPrefs;
        [Inject] private readonly ICardInfoLoader cardInfo;
        [Inject] private readonly ICampaignLoader campaignRepository;
        [Inject] private readonly IInvestigatorInfoLoader investigatorRepository;
        [Inject] private readonly IUnlockCardsLoader unlockCardsRepository;
        [Inject] private readonly IInvestigatorSelectorLoader investigatorSelectorRepository;
        [Inject] private readonly ICardInfo cardInfoRepository;
        [Inject] private readonly IInstantiatorAdapter instantiator;

        /*******************************************************************/
        public void LoadDataCards() =>
            cardInfo.CardInfoList = serializer.CreateDataFromResources<List<CardInfo>>(gameFiles.CardsDataFilePath);

        public void LoadSettings() => settings.AreCardsVisible = playerPrefs.LoadCardsVisibility();

        public void SaveProgress()
        {
            serializer.SaveFileFromData(campaignRepository, gameFiles.PlayerProgressFilePath);
            serializer.SaveFileFromData(investigatorRepository, gameFiles.PlayerProgressFilePath);
            serializer.SaveFileFromData(unlockCardsRepository, gameFiles.PlayerProgressFilePath);
            serializer.SaveFileFromData(investigatorSelectorRepository, gameFiles.PlayerProgressFilePath);
        }

        public void LoadProgress(bool isNewGame) =>
            Load(isNewGame ? gameFiles.PlayerProgressDefaultFilePath : gameFiles.PlayerProgressFilePath);

        private void Load(string filePath)
        {
            serializer.UpdateDataFromFile(filePath, campaignRepository);
            serializer.UpdateDataFromFile(filePath, investigatorRepository);
            serializer.UpdateDataFromFile(filePath, unlockCardsRepository);
            serializer.UpdateDataFromFile(filePath, investigatorSelectorRepository);
            LoadDependency();
        }

        private void LoadDependency()
        {
            foreach (InvestigatorInfo investigator in investigatorRepository.InvestigatorsList)
            {
                investigator.Info = cardInfoRepository.Get(investigator.Id);
                investigator.DeckBuilding = instantiator.CreateInstance<DeckBuildingRules>(investigator.Id);
            }
        }
    }
}
