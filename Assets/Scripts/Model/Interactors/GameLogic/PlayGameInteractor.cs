using Arkham.Entities;
using Arkham.Repositories;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Interactors
{
    public class PlayGameInteractor : IPlayGameInteractor
    {
        [Inject] private readonly IInvestigatorInfo investigatorRepository;
        [Inject] private readonly IInvestigatorSelectorInfo investigatorSelectorRepository;
        //[Inject] private readonly ICampaignRepository campaignRepository;

        private List<InvestigatorInfo> InvestigatorsWithCards =>
                investigatorRepository.FindAll(investigator => investigator.Deck.Count > 0 && !investigator.IsPlaying);
        public bool GameIsReadyToPlay => investigatorRepository.Exists(investigator => investigator.SelectionIsFull
                && investigatorSelectorRepository.Contains(investigator.Id));

        /*******************************************************************/
        public void Ready()
        {
            foreach (InvestigatorInfo investigator in InvestigatorsWithCards)
                investigator.IsPlaying = true;

            //StartScenario(campaignRepository.CurrentScenario);
        }
    }
}
