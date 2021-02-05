using Arkham.Repositories;
using Arkham.Views;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public class CampaignController : IFullController<ICampaignView>
    {
        private readonly Repository repository;

        /*******************************************************************/
        public CampaignController(Repository repository) => this.repository = repository;

        /*******************************************************************/
        void IClickController<ICampaignView>.Click(ICampaignView campaignView, PointerEventData eventData)
        {
            if (!campaignView.IsOpen) return;
            repository.CurrentScenario = campaignView.FirstScenarioId;
            campaignView.ClickEffect();
        }

        void IHoverController<ICampaignView>.HoverOn(ICampaignView campaignView, PointerEventData eventData) =>
           campaignView.HoverOnEffect();

        void IHoverController<ICampaignView>.HoverOff(ICampaignView campaignView, PointerEventData eventData) =>
           campaignView.HoverOffEffect();
    }
}
