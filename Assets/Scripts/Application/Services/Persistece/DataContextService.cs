using Arkham.Application.GamePlay;
using Arkham.Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Arkham.Application
{
    public class DataContextService
    {
        [Inject] private readonly JsonNewtonsoftService serializer;
        [Inject] private readonly DataMapperService mapper;
        [Inject] private readonly GameFiles gameFiles;
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly CampaignRepository campaignRepository;
        [Inject] private readonly ZonesManager zonesManager;
        [Inject] private readonly SelectorRepository selectorRepository;

        /*******************************************************************/
        public void LoadInfoCards()
        {
            List<CardInfo> cards = serializer.CreateDataFromResources<List<CardInfo>>(gameFiles.CardsDataFilePath);
            cardRepository.CreateWith(cards);
        }

        public void SaveProgress() => serializer.SaveFileFromData(mapper.CreateDTO(), gameFiles.PlayerProgressFilePath);

        public void LoadProgress(StartGame gameType)
        {
            FullDTO repositoryDTO = gameType == StartGame.New ? LoadNewGame() : LoadContinue();
            mapper.MapCampaigns(repositoryDTO.CampaignsList, repositoryDTO.CurrentScenario);
            mapper.MapInvestigator(repositoryDTO.InvestigatorsList);
            mapper.MapSelector(repositoryDTO.InvestigatorsSelectedList);
            mapper.MapUnlockCards(repositoryDTO.UnlockCards);

            FullDTO LoadNewGame() => serializer.CreateDataFromResources<FullDTO>(gameFiles.PlayerProgressDefaultFilePath);
            FullDTO LoadContinue() => serializer.CreateDataFromFile<FullDTO>(gameFiles.PlayerProgressFilePath);
        }

        public void LoadScene()
        {
            mapper.MapZones(zonesManager.AllZones);
        }

        public void LoadScenarioCards()
        {
            List<string> allScenarioCards = new List<string>();
            foreach (string cardType in gameFiles.ALL_SCENARIO_CARDS_FILES)
            {
                Debug.Log("esce:" + campaignRepository.CurrentScenario);
                string encounterPath = gameFiles.DECK_PATH(campaignRepository.CurrentScenario.Id) + cardType;
                allScenarioCards.AddRange(serializer.CreateDataFromFile<List<string>>(encounterPath));
            }
            mapper.MapCard(allScenarioCards);
        }

        public void LoadInvestigatorsCards()
        {
            List<string> allInvestigatorCards = new List<string>();
            foreach (Investigator investigator in selectorRepository.InvestigatorsInSelector)
            {
                allInvestigatorCards.Add(investigator.Id);
                allInvestigatorCards.AddRange(investigator.FullDeck.Select(investigator => investigator.Id));
            }
            mapper.MapCard(allInvestigatorCards);
        }
    }
}
