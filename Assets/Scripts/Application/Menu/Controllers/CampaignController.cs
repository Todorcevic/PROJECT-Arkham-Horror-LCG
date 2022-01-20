using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CampaignController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private CampaignView campaignView;
        [Inject] private readonly SelectScenarioUseCase selectScenarioUseCase;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!campaignView.IsClickable) return;
            campaignView.ClickEffect();
            selectScenarioUseCase.SelectFirstScenarioOf(campaignView.Id);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => campaignView.HoverOnEffect();

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => campaignView.HoverOffEffect();
    }
}
