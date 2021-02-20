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
        [Inject] private readonly ICampaignInteractor campaignInteractor;

        /*******************************************************************/
        public void Init(ICampaignView campaignView)
        {
            campaignView.Interactable.AddClickAction(() => Click(campaignView));
            campaignView.Interactable.AddHoverOnAction(() => campaignView.HoverOn());
            campaignView.Interactable.AddHoverOffAction(() => campaignView.HoverOff());
        }

        private void Click(ICampaignView campaignView)
        {
            if (!campaignView.CurrentState.IsOpen) return;
            campaignInteractor.AddScenarioToPlay(campaignView.FirstScenarioId);
            campaignView.Click();
        }
    }
}
