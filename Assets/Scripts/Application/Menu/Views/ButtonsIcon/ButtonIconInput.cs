using UnityEngine;
using UnityEngine.EventSystems;

namespace Arkham.Application.MainMenu
{
    public class ButtonIconInput : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private ButtonIconView buttonIconView;

        public void OnPointerClick(PointerEventData eventData) => buttonIconView.PointerClick();

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            buttonIconView.HoverOnEffect();
        }

        public void OnPointerExit(PointerEventData eventData) => buttonIconView.HoverOffEffect();
    }
}
