using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CampaignController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private CampaignView campaignView;
        [Inject] private readonly SelectScenarioUseCase selectScenarioUseCase;
        [Inject(Id = "MainPanelsManager")] private readonly PanelsMediator panelsManager;
        [Inject(Id = "ChooseCardPanel")] private readonly PanelView panelToShow;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!campaignView.IsClickable) return;
            campaignView.ClickEffect();
            selectScenarioUseCase.SelectFirstScenarioOf(campaignView.Id);
            panelsManager.SelectPanel(panelToShow);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => campaignView.HoverOnEffect();

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => campaignView.HoverOffEffect();
    }
}
