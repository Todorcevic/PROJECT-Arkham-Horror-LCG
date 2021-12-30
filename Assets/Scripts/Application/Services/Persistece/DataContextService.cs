using Arkham.Model;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Arkham.Application
{
    public class DataContextService
    {
        [Inject] private readonly JsonNewtonsoftService serializer;
        [Inject] private readonly DataMapperService mapper;
        [Inject] private readonly GameFiles gameFiles;
        [Inject] private readonly CardsRepository cardRepository;
        [Inject] private readonly CampaignsRepository campaignRepository;
        [Inject] private readonly SelectorsRepository selectorRepository;

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

        public void LoadGameCards()
        {
            IEnumerable<string> allCards = GetScenarioCards().Concat(GetInvestigatorsCards());
            mapper.MapCard(allCards);

            List<string> GetScenarioCards()
            {
                List<string> allScenarioCards = new List<string>();
                foreach (string cardType in gameFiles.ALL_SCENARIO_CARDS_FILES)
                {
                    string encounterPath = gameFiles.DeckPath(campaignRepository.CurrentScenario.Id) + cardType;
                    allScenarioCards.AddRange(serializer.CreateDataFromResources<List<string>>(encounterPath));
                }
                return allScenarioCards;
            }

            List<string> GetInvestigatorsCards()
            {
                List<string> allInvestigatorCards = new List<string>();
                foreach (Investigator investigator in selectorRepository.InvestigatorsInSelector)
                {
                    allInvestigatorCards.Add(investigator.Id);
                    allInvestigatorCards.AddRange(investigator.FullDeckId);
                }
                return allInvestigatorCards;
            }
        }
    }
}
