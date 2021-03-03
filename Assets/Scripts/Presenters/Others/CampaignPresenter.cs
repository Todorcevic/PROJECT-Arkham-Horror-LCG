using Arkham.Managers;
using Arkham.Interactors;
using Zenject;

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
        public void SetCampaign(string campaignId)
        {
            string stateId = campaignInteractor.GetState(campaignId);
            campaignsManager.ExecuteStateWithCampaign(stateId, campaignId);
        }

        private void InitializeCampaigns()
        {
            foreach (string campaignId in campaignInteractor.CampaignsList)
                SetCampaign(campaignId);
        }
    }
}
