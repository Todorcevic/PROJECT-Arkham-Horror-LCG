using Arkham.Repositories;
using Arkham.Views;
using Arkham.Models;
using Arkham.Managers;
using UniRx;
using System.Collections.Generic;

namespace Arkham.Presenters
{
    public class CampaignPresenter : IPresenter<ICampaignView>
    {
        private readonly Repository allData;
        private readonly ICampaignManager campaignManager;

        /*******************************************************************/
        public CampaignPresenter(Repository allData, ICampaignManager campaignManager)
        {
            this.allData = allData;
            this.campaignManager = campaignManager;
        }

        /*******************************************************************/
        public void CreateReactiveViewModel(ICampaignView campaignView)
        {
            Campaign campaign = allData.AllCampaigns[campaignView.Id];
            campaign.ObserveEveryValueChanged(c => c.State)
                .Subscribe(campaignStateId => campaignManager.SetState(campaignView, campaignStateId));
        }
    }
}
