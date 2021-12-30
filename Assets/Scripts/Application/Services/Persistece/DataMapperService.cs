using Arkham.Model;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Arkham.Application
{
    public class DataMapperService
    {
        [Inject] private readonly CardsRepository cardRepository;
        [Inject] private readonly CampaignsRepository campaignRepository;
        [Inject] private readonly InvestigatorsRepository investigatorRepository;
        [Inject] private readonly SelectorsRepository selectorRepository;
        [Inject] private readonly UnlockCardsRepository unlockCardsRepository;
        [Inject] private readonly ZonesRepository zonesRepository;
        [Inject] private readonly CardsInGameRepository cardsInGameRepository;
        [Inject] private readonly PlayersRepository playersRepository;
        [Inject] private readonly NameConventionFactoryService factory;

        /*******************************************************************/
        public FullDTO CreateDTO()
        {
            FullDTO fullDTO = new FullDTO { CurrentScenario = campaignRepository.CurrentScenario.Id };

            foreach (Campaign campaign in campaignRepository.Campaigns)
            {
                CampaignDTO campaignDTO = new CampaignDTO
                {
                    Id = campaign.Id,
                    State = campaign.State.Id
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

        public void MapUnlockCards(IEnumerable<string> unlockCards)
        {
            unlockCardsRepository.Reset();
            foreach (string cardId in unlockCards)
                unlockCardsRepository.Add(cardRepository.Get(cardId));
        }

        public void MapSelector(IEnumerable<string> investigatorsSelected)
        {
            selectorRepository.Reset();
            foreach (string investigatorId in investigatorsSelected)
                selectorRepository.Add(investigatorRepository.Get(investigatorId));
        }

        public void MapInvestigator(IEnumerable<InvestigatorDTO> investigators)
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
                    cardRepository.Get(investigator.Id),
                    factory.CreateInstance<DeckBuildingRules>(investigator.Id)
                    );

                investigator.MandatoryCards.ForEach(card => newInvestigator.AddToMandatory(cardRepository.Get(card)));
                investigator.Deck.ForEach(card => newInvestigator.AddToDeck(cardRepository.Get(card)));
                investigatorRepository.Add(newInvestigator);
            }
        }

        public void MapCampaigns(IEnumerable<CampaignDTO> campaigns, string currentScenario)
        {
            campaignRepository.Reset();
            foreach (CampaignDTO campaign in campaigns)
            {
                Campaign newCampaing = new Campaign
                {
                    Id = campaign.Id,
                    State = factory.CreateInstance<CampaignState>(campaign.State),
                    FirstScenario = factory.CreateInstance<Scenario>(campaign.FirstScenario)
                };
                campaignRepository.Add(newCampaing);
                campaignRepository.CurrentScenario = factory.CreateInstance<Scenario>(currentScenario);
            }
        }

        public Card MapCard(string cardId)
        {
            Card newCard = factory.CreateInstance<Card>(cardId);
            newCard.CreateWithThisCard(cardRepository.Get(cardId));
            return newCard;
        }

        public void MapZones()
        {
            zonesRepository.Reset();
            zonesRepository.Add(zonesRepository.EncounterZone);
            zonesRepository.Add(zonesRepository.DiscardZone);
            zonesRepository.Add(zonesRepository.ScenarioZone);
            zonesRepository.Add(zonesRepository.ActZone);
            zonesRepository.Add(zonesRepository.AgendaZone);
            zonesRepository.Add(zonesRepository.PlayingZone);
            zonesRepository.Add(zonesRepository.SkillTestZone);
            zonesRepository.Add(zonesRepository.OutSideZone);
            zonesRepository.Add(zonesRepository.VictoryZone);
            for (int i = 0; i < 12; i++)
                zonesRepository.Locations.Add(new Zone(ZoneType.Location));
            zonesRepository.AddRange(zonesRepository.Locations);

            foreach (Player player in playersRepository.AllPlayers)
            {
                zonesRepository.Add(player.InvestigatorZone);
                zonesRepository.Add(player.HandZone);
                zonesRepository.Add(player.DeckZone);
                zonesRepository.Add(player.DiscardZone);
                zonesRepository.Add(player.AssetZone);
                zonesRepository.Add(player.ThreatZone);
            }
            zonesRepository.AddRange(cardsInGameRepository.AllListCards.Select(card => card.CardZone));
        }
    }
}
