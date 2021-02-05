using Arkham.Repositories;
using Arkham.Views;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public class CampaignController : ISemiFullController<ICampaignView>
    {
        private readonly Repository repository;

        /*******************************************************************/
        public CampaignController(Repository repository) => this.repository = repository;

        /*******************************************************************/
        public void Click(ICampaignView campaignView, PointerEventData eventData)
        {
            if (!campaignView.IsOpen) return;
            repository.CurrentScenario = campaignView.FirstScenarioId;
            campaignView.ClickEffect();
        }

        public void HoverOn(ICampaignView campaignView, PointerEventData eventData) =>
           campaignView.HoverOnEffect();

        public void HoverOff(ICampaignView campaignView, PointerEventData eventData) =>
           campaignView.HoverOffEffect();
    }
}
