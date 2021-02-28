using Arkham.Managers;
using Arkham.Models;
using Arkham.ScriptableObjects;
using Arkham.Views;
using System.Linq;
using Zenject;
using Arkham.Interactors;
using System.Collections;

namespace Arkham.Presenters
{
    public class CampaignPresenter : ICampaignPresenter, IInitializablePresenter
    {
        [Inject] private readonly ICampaignsManager campaignsManager;
        [Inject] private readonly ICampaignInteractor campaignInteractor;
        IEnumerable IInitializablePresenter.interactableViews =>
            campaignsManager.Campaigns.OfType<IInteractableView>();

        /*******************************************************************/
        void IInitializablePresenter.Init()
        {
            campaignInteractor.CampaignStateChanged += SetCampaign;
            InitializeCampaigns();
        }

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
