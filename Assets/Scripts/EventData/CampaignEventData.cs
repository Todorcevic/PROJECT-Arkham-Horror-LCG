using Arkham.Repositories;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class CampaignEventData : IChangeCampaign, ICampaignEvent
    {
        [Inject] private readonly ICampaignRepository campaignRepository;
        public event Action<string, string> CampaignStateChanged;

        /*******************************************************************/
        public void ChangeCampaignState(string campaignId, string state)
        {
            campaignRepository.GetCampaign(campaignId).State = state;
            CampaignStateChanged?.Invoke(campaignId, state);
        }

        public void SelectScenario(string scenarioId) => campaignRepository.CurrentScenario = scenarioId;
    }
}
