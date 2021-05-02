using Arkham.Config;
using Arkham.Model;
using Arkham.Services;
using System;
using Zenject;

namespace Arkham.Adapter
{
    public class CampaignEventDomain
    {
        [Inject] private readonly CampaignRepository campaignManager;
        [Inject] private readonly IConventionFactory factory;
        private event Action<string, string> CampaignStateChanged;

        /*******************************************************************/
        public void ChangeState(string campaignId, string state)
        {
            campaignManager.Get(campaignId).State = factory.CreateInstance<CampaignState>(state);
            CampaignStateChanged?.Invoke(campaignId, state);
        }

        public void Subscribe(Action<string, string> action) => CampaignStateChanged += action;
    }
}
