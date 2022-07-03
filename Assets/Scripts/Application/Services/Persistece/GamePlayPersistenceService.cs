using Arkham.Model;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Application
{
    public class GamePlayPersistenceService
    {
        [Inject] private readonly PlayersRepository playersRepository;
        [Inject] private readonly CardsInGameRepository cardsInGameRepository;
        [Inject] private readonly ZonesRepository zonesRepository;
        [Inject] private readonly CampaignsRepository campaignRepository;
        [Inject] private readonly SelectorsRepository selectorRepository;
        [Inject] private readonly CardFactoryService cardFactory;
        [Inject] private readonly PlayerFactoryService playerFactoryService;
        [Inject] private readonly JsonNewtonsoftService serializer;
        [Inject] private readonly GameFiles gameFiles;

        /*******************************************************************/
        public void LoadGameData()
        {
            ResetAll();
            LoadScenarioCards();
            LoadInvestigatorsCardsAndPlayers();

            void ResetAll()
            {
                cardsInGameRepository.Reset();
                playersRepository.Reset();
                zonesRepository.Reset(campaignRepository.CurrentScenario.LocationsAmount);
            }

            void LoadScenarioCards()
            {
                foreach (string cardType in gameFiles.ALL_SCENARIO_CARDS_FILES)
                {
                    string scenarioFilesPath = gameFiles.DeckPath(campaignRepository.CurrentScenario.Id) + cardType;
                    serializer.CreateDataFromResources<List<string>>(scenarioFilesPath).ForEach(cardId => cardFactory.BuildCard(cardId));
                }
            }

            void LoadInvestigatorsCardsAndPlayers()
            {
                foreach (Investigator investigator in selectorRepository.InvestigatorsInSelector)
                {
                    Player newPlayer = playerFactoryService.BuildPlayer();
                    cardFactory.BuildCard(investigator.Id, newPlayer);
                    investigator.FullDeckId.ForEach(cardId => cardFactory.BuildCard(cardId, newPlayer));
                }
            }
        }
    }
}
