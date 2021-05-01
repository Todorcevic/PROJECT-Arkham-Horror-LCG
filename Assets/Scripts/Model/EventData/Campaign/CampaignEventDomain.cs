using System;
using Zenject;

namespace Arkham.Model
{
    public class CampaignEventDomain
    {
        [Inject] private readonly CampaignRepository campaignManager;
        private event Action<string, string> CampaignStateChanged;

        /*******************************************************************/
        public void ChangeState(string campaignId, string state)
        {
            campaignManager.Get(campaignId).State = campaignManager.GetState(state);
            CampaignStateChanged?.Invoke(campaignId, state);
        }

        public void Subscribe(Action<string, string> action) => CampaignStateChanged += action;
    }
}
