using Arkham.Interactors;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Controllers
{
    public class CampaignController : ICampaignController
    {
        private readonly ICampaignView campaignView;
        private readonly ICampaignInteractor campaignInteractor;

        /*******************************************************************/
        public CampaignController(ICampaignView campaignView, ICampaignInteractor campaignIterator)
        {
            this.campaignView = campaignView;
            this.campaignInteractor = campaignIterator;
            Init();
        }

        public void Init()
        {
            campaignView.Interactable.AddClickAction(() => Click());
            campaignView.Interactable.AddHoverOnAction(() => campaignView.HoverOn());
            campaignView.Interactable.AddHoverOffAction(() => campaignView.HoverOff());
        }

        private void Click()
        {
            if (!campaignView.CurrentState.IsOpen) return;
            campaignInteractor.AddScenarioToPlay(campaignView.FirstScenarioId);
            campaignView.Click();
        }
    }
}
