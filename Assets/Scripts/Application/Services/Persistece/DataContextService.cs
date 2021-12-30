using Arkham.Model;
using System.Collections.Generic;
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
        [Inject] private readonly PlayersRepository playersRepository;
        [Inject] private readonly CardsInGameRepository cardsInGameRepository;

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
            cardsInGameRepository.Reset();
            SetScenarioCards();
            SetInvestigatorsCardsAndPlayers();

            void SetScenarioCards()
            {
                foreach (string cardType in gameFiles.ALL_SCENARIO_CARDS_FILES)
                {
                    string encounterPath = gameFiles.DeckPath(campaignRepository.CurrentScenario.Id) + cardType;
                    serializer.CreateDataFromResources<List<string>>(encounterPath).ForEach(cardId => mapper.MapCard(cardId));
                }
            }

            void SetInvestigatorsCardsAndPlayers()
            {
                playersRepository.Reset();
                foreach (Investigator investigator in selectorRepository.InvestigatorsInSelector)
                {
                    Player newPlayer = new Player(investigator, mapper.MapCard(investigator.Id) as InvestigatorCard);
                    investigator.FullDeckId.ForEach(cardId => newPlayer.AddCardInDeck(mapper.MapCard(cardId)));
                    playersRepository.AddPlayer(newPlayer);
                }
            }
        }
    }
}
