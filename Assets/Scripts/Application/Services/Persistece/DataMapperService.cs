using Arkham.Application.Gameplay;
using Arkham.Model;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Application
{
    public class DataMapperService
    {
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly CampaignRepository campaignRepository;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly SelectorRepository selectorRepository;
        [Inject] private readonly UnlockCardsRepository unlockCardsRepository;
        [Inject] private readonly NameConventionFactoryService factory;
        [Inject] private readonly ZonesRepository zonesRepository;
        [Inject] private readonly ZonesManager zonesManager;

        /*******************************************************************/
        public FullDTO CreateDTO()
        {
            FullDTO fullDTO = new FullDTO { CurrentScenario = campaignRepository.CurrentScenario.Id };

            foreach (Campaign campaign in campaignRepository.Campaigns)
            {
                CampaignDTO campaignDTO = new CampaignDTO()
                {
                    Id = campaign.Id,
                    State = campaign.State.Id
                };
                fullDTO.CampaignsList.Add(campaignDTO);
            }

            foreach (Investigator investigator in investigatorRepository.Investigators)
            {
                InvestigatorDTO investigatorDTO = new InvestigatorDTO()
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

        public void MapUnlockCards(List<string> unlockCards)
        {
            unlockCardsRepository.Reset();
            foreach (string cardId in unlockCards)
                unlockCardsRepository.Add(cardRepository.Get(cardId));
        }

        public void MapSelector(List<string> investigatorsSelected)
        {
            selectorRepository.Reset();
            foreach (string investigatorId in investigatorsSelected)
                selectorRepository.Add(investigatorRepository.Get(investigatorId));
        }

        public void MapInvestigator(List<InvestigatorDTO> investigators)
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

                foreach (string card in investigator.MandatoryCards)
                    newInvestigator.AddToMandatory(cardRepository.Get(card));
                foreach (string card in investigator.Deck)
                    newInvestigator.AddToDeck(cardRepository.Get(card));
                investigatorRepository.Add(newInvestigator);
            }
        }

        public void MapCampaigns(List<CampaignDTO> campaigns, string currentScenario)
        {
            campaignRepository.Reset();
            foreach (CampaignDTO campaign in campaigns)
            {
                Campaign newCampaing = new Campaign()
                {
                    Id = campaign.Id,
                    State = factory.CreateInstance<CampaignState>(campaign.State),
                    FirstScenario = factory.CreateInstance<Scenario>(campaign.FirstScenario)
                };
                campaignRepository.Add(newCampaing);
                campaignRepository.CurrentScenario = factory.CreateInstance<Scenario>(currentScenario);
            }
        }

        public void MapZones()
        {
            zonesRepository.Reset();
            foreach (ZoneView zone in zonesManager.AllZones)
            {
                Zone newZone = new Zone()
                {
                    Guid = zone.Guid,
                    Type = zone.ZoneType
                };
                zonesRepository.Add(newZone);
            }
        }
    }
}
