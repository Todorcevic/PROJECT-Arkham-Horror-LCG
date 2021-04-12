using System.Collections.Generic;
using Arkham.Entities;
using Arkham.Config;
using Arkham.Repositories;
using Zenject;
using System.Linq;
using Arkham.Investigators;

namespace Arkham.Services
{
    public class DataPersistence : IDataPersistence
    {
        [Inject] private readonly GameFiles gameFiles;
        [Inject] private readonly Repository repository;
        [Inject] private readonly ISerializer serializer;
        [Inject] private readonly IInstantiatorAdapter instantiator;
        [Inject] private readonly IPlayerPrefsAdapter playerPrefs;

        /*******************************************************************/
        public void LoadDataCards()
        {
            repository.CardInfoList = serializer.CreateDataFromResources<List<CardInfo>>(gameFiles.CardsDataFilePath);
            repository.CardInfoDict = repository.CardInfoList.ToDictionary(c => c.Code);
        }

        public void SaveProgress() => serializer.SaveFileFromData(repository, gameFiles.PlayerProgressFilePath);

        public void LoadProgress()
        {
            serializer.UpdateDataFromFile(gameFiles.PlayerProgressFilePath, repository);
            LoadDeckBuildingRules();
        }

        public void LoadSettings()
        {
            repository.AreCardsVisible = playerPrefs.LoadCardsVisibility();
        }

        public void NewGame()
        {
            serializer.UpdateDataFromResources(gameFiles.PlayerProgressDefaultFilePath, repository);
            LoadDeckBuildingRules();
        }

        private void LoadDeckBuildingRules()
        {
            foreach (InvestigatorInfo investigator in repository.InvestigatorsList)
                investigator.DeckBuilding = instantiator.CreateInstance<DeckBuildingRules>(investigator.Id);
        }
    }
}
