using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CardInput : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDropHandler
    {
        [Inject] private readonly CardShowerManager cardShowerManager;
        [SerializeField] private CardView cardView;

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => cardView.PointerClick();

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            cardView.PointerEnter();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => cardView.PointerExit();

        void IDropHandler.OnDrop(PointerEventData eventData)
        {
            if (cardShowerManager.CheckIsShow(cardView)) return;
            cardView.PointerEnter();
        }
    }
}
