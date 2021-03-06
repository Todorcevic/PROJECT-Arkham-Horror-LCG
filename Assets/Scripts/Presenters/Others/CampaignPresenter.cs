using Arkham.Managers;
using Arkham.Interactors;
using Arkham.EventData;
using Arkham.SettingObjects;
using Zenject;

namespace Arkham.Presenters
{
    public class CampaignPresenter : IInitializable
    {
        [Inject] private readonly ICampaignsManager campaignsManager;
        [Inject] private readonly ICampaignEvent changeCampaignEventData;
        [Inject] private readonly ICampaignInteractor campaignInteractor;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            changeCampaignEventData.CampaignStateChanged += ExecuteStateWithCampaign;
            InitializeCampaigns();
        }

        /*******************************************************************/
        private void ExecuteStateWithCampaign(string campaignId, string state)
        {
            ICampaignConfigurable campaignView = campaignsManager.GetCampaign(campaignId);
            campaignsManager.GetState(state).ExecuteState(campaignView);
        }

        private void InitializeCampaigns()
        {
            foreach (string campaignId in campaignInteractor.CampaignsList)
            {
                string state = campaignInteractor.GetState(campaignId);
                ExecuteStateWithCampaign(campaignId, state);
            }
        }
    }
}
