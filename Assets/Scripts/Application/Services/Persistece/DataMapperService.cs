using Arkham.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Zenject;

namespace Arkham.Application
{
    public class DataMapperService
    {
        [Inject] private readonly JsonNewtonsoftService serializer;
        [Inject] private readonly GameFiles gameFiles;
        [Inject] private readonly ApplicationValues applicationValues;
        [Inject] private readonly CardsInfoRepository cardInfoRepository;
        [Inject] private readonly CampaignsRepository campaignRepository;
        [Inject] private readonly SelectorsRepository selectorRepository;
        [Inject] private readonly InvestigatorsRepository investigatorRepository;
        [Inject] private readonly UnlockCardsRepository unlockCardsRepository;
        [Inject] private readonly PlayersRepository playersRepository;
        [Inject] private readonly CardsInGameRepository cardsInGameRepository;
        [Inject] private readonly ZonesRepository zonesRepository;
        [Inject] private readonly CardFactoryService cardFactory;
        [Inject] private readonly NameConventionFactoryService factory;

        /*******************************************************************/
        public void LoadInfoCards()
        {
            List<CardInfo> cards = serializer.CreateDataFromResources<List<CardInfo>>(gameFiles.CardsDataFilePath);
            cardInfoRepository.CreateWith(cards);
        }

        public void SaveProgress()
        {
            serializer.SaveFileFromData(CreateDTO(), gameFiles.PlayerProgressFilePath);

            FullDTO CreateDTO()
            {
                FullDTO fullDTO = new FullDTO { CurrentScenario = campaignRepository.CurrentScenario?.Id };

                foreach (Campaign campaign in campaignRepository.Campaigns)
                {
                    CampaignDTO campaignDTO = new CampaignDTO
                    {
                        Id = campaign.Id,
                        State = campaign.State,
                        FirstScenario = campaign.FirstScenario.Id
                    };
                    fullDTO.CampaignsList.Add(campaignDTO);
                }

                foreach (Investigator investigator in investigatorRepository.Investigators)
                {
                    InvestigatorDTO investigatorDTO = new InvestigatorDTO
                    {
                        Id = investigator.Id,
                        PhysicTrauma = investigator.PhysicTrauma,
                        MentalTrauma = investigator.MentalTrauma,
                        Xp = investigator.Xp,
                        IsPlaying = investigator.IsPlaying,
                        IsRetired = investigator.State == InvestigatorState.Retired
                    };

                    investigatorDTO.Deck = investigator.CardsInDeckIds;
                    investigatorDTO.MandatoryCards = investigator.MandatoryCardsIds;
                    fullDTO.InvestigatorsList.Add(investigatorDTO);
                }

                fullDTO.InvestigatorsSelectedList = selectorRepository.InvestigatorsIdInSelector;
                fullDTO.UnlockCards = unlockCardsRepository.Serialize();
                return fullDTO;
            }
        }

        public void RemoveProgress() => File.Delete(gameFiles.PlayerProgressFilePath);

        public void LoadProgress()
        {
            FullDTO repositoryDTO = applicationValues.CanContinue ? ContinueData() : NewGameData();
            LoadCampaigns(repositoryDTO.CampaignsList, repositoryDTO.CurrentScenario);
            LoadInvestigators(repositoryDTO.InvestigatorsList);
            LoadSelectors(repositoryDTO.InvestigatorsSelectedList);
            LoadUnlockCards(repositoryDTO.UnlockCards);

            FullDTO NewGameData() => serializer.CreateDataFromResources<FullDTO>(gameFiles.PlayerProgressDefaultFilePath);
            FullDTO ContinueData() => serializer.CreateDataFromFile<FullDTO>(gameFiles.PlayerProgressFilePath);

            void LoadCampaigns(IEnumerable<CampaignDTO> campaigns, string currentScenario)
            {
                campaignRepository.Reset();
                campaignRepository.SetScenario(factory.CreateInstance<Scenario>(currentScenario));
                foreach (CampaignDTO campaign in campaigns)
                {
                    Campaign newCampaing = new Campaign
                    {
                        Id = campaign.Id,
                        State = campaign.State,
                        FirstScenario = factory.CreateInstance<Scenario>(campaign.FirstScenario)
                    };
                    campaignRepository.Add(newCampaing);
                }
            }

            void LoadInvestigators(IEnumerable<InvestigatorDTO> investigators)
            {
                investigatorRepository.Reset();
                foreach (InvestigatorDTO investigator in investigators)
                {
                    Investigator newInvestigator = new Investigator(
                        investigator.PhysicTrauma,
                        investigator.MentalTrauma,
                        investigator.Xp,
                        investigator.IsPlaying,
                        investigator.IsRetired,
                        cardInfoRepository.GetInfo(investigator.Id),
                        factory.CreateInstance<DeckBuildingRules>(investigator.Id)
                        );

                    investigator.MandatoryCards.ForEach(card => newInvestigator.AddToMandatory(cardInfoRepository.GetInfo(card)));
                    investigator.Deck.ForEach(card => newInvestigator.AddToDeck(cardInfoRepository.GetInfo(card)));
                    investigatorRepository.Add(newInvestigator);
                }
            }

            void LoadSelectors(IEnumerable<string> investigatorsSelected)
            {
                selectorRepository.Reset();
                foreach (string investigatorId in investigatorsSelected)
                    selectorRepository.Add(investigatorRepository.Get(investigatorId));
            }

            void LoadUnlockCards(IEnumerable<string> unlockCards)
            {
                unlockCardsRepository.Reset();
                foreach (string cardId in unlockCards)
                    unlockCardsRepository.Add(cardInfoRepository.GetInfo(cardId));
            }
        }

        public void LoadGameData()
        {
            cardsInGameRepository.Reset();
            LoadScenarioCards();
            LoadInvestigatorsCardsAndPlayers();
            LoadZones();
            SetCardsInZone();

            void LoadScenarioCards()
            {
                foreach (string cardType in gameFiles.ALL_SCENARIO_CARDS_FILES)
                {
                    string encounterPath = gameFiles.DeckPath(campaignRepository.CurrentScenario.Id) + cardType;
                    serializer.CreateDataFromResources<List<string>>(encounterPath).ForEach(cardId => cardFactory.BuildCard(cardId));
                }
            }

            void LoadInvestigatorsCardsAndPlayers()
            {
                playersRepository.Reset();
                foreach (Investigator investigator in selectorRepository.InvestigatorsInSelector)
                {
                    InvestigatorCard investigatorCard = cardFactory.BuildCard(investigator.Id) as InvestigatorCard;
                    Player newPlayer = new Player(investigatorCard);
                    investigator.FullDeckId.ForEach(cardId => newPlayer.AddCardInDeck(cardFactory.BuildCard(cardId)));
                    playersRepository.AddPlayer(newPlayer);
                }
            }

            void LoadZones()
            {
                zonesRepository.Reset();
                zonesRepository.BuildLocationsZones(campaignRepository.CurrentScenario.LocationsAmount);
            }

            void SetCardsInZone()
            {
                foreach (Card card in cardsInGameRepository.AllListCards)
                    zonesRepository.OutSideZone.EnterThisCard(card);
            }
        }
    }
}
