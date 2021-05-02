using Arkham.Model;
using Zenject;

namespace Arkham.Services
{
    public class DataMapper : IMapper
    {
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly CampaignRepository campaignRepository;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly Selector selectorRepository;
        [Inject] private readonly UnlockCardsRepository unlockCardsRepository;
        [Inject] private readonly IConventionFactory factory;

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
                    IsRetired = investigator.IsRetired
                };

                investigatorDTO.Deck = investigator.CardsInDeckIds;
                investigatorDTO.MandatoryCards = investigator.MandatoryCardsIds;
                fullDTO.InvestigatorsList.Add(investigatorDTO);
            }

            fullDTO.InvestigatorsSelectedList = selectorRepository.Ids;
            fullDTO.UnlockCards = unlockCardsRepository.Serialize();
            return fullDTO;
        }

        public void MapUnlockCards(FullDTO repositoryDTO)
        {
            unlockCardsRepository.Reset();
            foreach (string cardId in repositoryDTO.UnlockCards)
                unlockCardsRepository.Add(cardRepository.Get(cardId));
        }

        public void MapSelector(FullDTO repositoryDTO)
        {
            selectorRepository.Reset();
            foreach (string investigatorId in repositoryDTO.InvestigatorsSelectedList)
                selectorRepository.Add(investigatorRepository.Get(investigatorId));
        }

        public void MapInvestigator(FullDTO repositoryDTO)
        {
            investigatorRepository.Reset();
            foreach (InvestigatorDTO investigator in repositoryDTO.InvestigatorsList)
            {
                Investigator newInvestigator = new Investigator()
                {
                    PhysicTrauma = investigator.PhysicTrauma,
                    MentalTrauma = investigator.MentalTrauma,
                    Xp = investigator.Xp,
                    IsPlaying = investigator.IsPlaying,
                    IsRetired = investigator.IsRetired
                };

                newInvestigator.Info = cardRepository.Get(investigator.Id);
                newInvestigator.DeckBuilder = factory.CreateInstance<DeckBuildingRules>(investigator.Id);
                foreach (string card in investigator.MandatoryCards)
                    newInvestigator.AddToMandatory(cardRepository.Get(card));
                foreach (string card in investigator.Deck)
                    newInvestigator.AddToDeck(cardRepository.Get(card));

                investigatorRepository.Add(newInvestigator);
            }
        }

        public void MapCampaigns(FullDTO repositoryDTO)
        {
            campaignRepository.Reset();

            foreach (CampaignDTO campaign in repositoryDTO.CampaignsList)
            {
                Campaign newCampaing = new Campaign()
                {
                    Id = campaign.Id,
                    State = factory.CreateInstance<CampaignState>(campaign.State),
                    FirstScenario = factory.CreateInstance<Scenario>(campaign.Firstscenario)
                };
                campaignRepository.Add(newCampaing);
                campaignRepository.CurrentScenario = factory.CreateInstance<Scenario>(repositoryDTO.CurrentScenario);
            }
        }
    }
}
