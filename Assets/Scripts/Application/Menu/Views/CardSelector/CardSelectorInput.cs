using UnityEngine;
using UnityEngine.EventSystems;

namespace Arkham.Application.MainMenu
{
    public class CardSelectorInput : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDropHandler
    {
        [SerializeField] private CardSelectorView cardSelectorView;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => cardSelectorView.PointerClick();

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            cardSelectorView.PointerEnter();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => cardSelectorView.PointerExit();

        void IDropHandler.OnDrop(PointerEventData eventData) => cardSelectorView.Drop();
    }
}
