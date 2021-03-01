using Arkham.Managers;
using Arkham.Models;
using Arkham.ScriptableObjects;
using Arkham.Views;
using Zenject;
using Arkham.Interactors;

namespace Arkham.Presenters
{
    public class CampaignPresenter : ICampaignPresenter, IInitializable
    {
        [Inject] private readonly ICampaignsManager campaignsManager;
        [Inject] private readonly ICampaignInteractor campaignInteractor;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            campaignInteractor.CampaignStateChanged += SetCampaign;
            InitializeCampaigns();
        }

        /*******************************************************************/
        public void SetCampaign(CampaignInfo campaignInfo)
        {
            ICampaignState state = campaignsManager.GetCampaignState(campaignInfo.State);
            ICampaignView campaign = campaignsManager.GetCampaign(campaignInfo.Id);
            state.ExecuteState(campaign);
            campaignInfo.IsOpen = state.IsOpen;
        }

        private void InitializeCampaigns()
        {
            foreach (CampaignInfo campaign in campaignInteractor.CampaignsList)
                SetCampaign(campaign);
        }
    }
}
