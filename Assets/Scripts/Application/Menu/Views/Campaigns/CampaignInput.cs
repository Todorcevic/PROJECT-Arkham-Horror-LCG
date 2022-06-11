using UnityEngine;
using UnityEngine.EventSystems;

namespace Arkham.Application.MainMenu
{
    public class CampaignInput : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private CampaignView campaignView;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => campaignView.PointerClick();

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => campaignView.HoverOnEffect();

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => campaignView.HoverOffEffect();
    }
}
