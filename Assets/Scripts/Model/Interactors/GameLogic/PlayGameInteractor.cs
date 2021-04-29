using System.Collections.Generic;
using Zenject;

namespace Arkham.Model
{
    public class PlayGameInteractor
    {
        [Inject] private readonly InvestigatorInfoRepository investigatorInfo;
        [Inject] private readonly InvestigatorSelectorRepository investigatorSelectorInfo;
        //[Inject] private readonly ICampaignRepository campaignRepository;

        private List<InvestigatorInfo> InvestigatorsWithCards =>
                investigatorInfo.FindAll(investigator => investigator.Deck.Count > 0 && !investigator.IsPlaying);
        public bool GameIsReadyToPlay => investigatorInfo.Exists(investigator => investigator.SelectionIsFull
                && investigatorSelectorInfo.Contains(investigator.Id));

        /*******************************************************************/
        public void Ready()
        {
            foreach (InvestigatorInfo investigator in InvestigatorsWithCards)
                investigator.IsPlaying = true;

            //StartScenario(campaignRepository.CurrentScenario);
        }
    }
}
