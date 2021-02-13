using Arkham.Repositories;
using Arkham.UI;
using Arkham.Views;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public class CampaignController : ICampaignController
    {
        [Inject] private readonly ICampaignRepository repository;

        /*******************************************************************/
        public void Click(ICampaignView campaignView)
        {
            if (!campaignView.IsOpen) return;
            campaignView.ClickEffect();
            repository.CurrentScenario = campaignView.FirstScenarioId;
        }

        public void HoverOn(ICampaignView campaignView) =>
            campaignView.HoverOnEffect();

        public void HoverOff(ICampaignView campaignView) =>
            campaignView.HoverOffEffect();
    }
}
