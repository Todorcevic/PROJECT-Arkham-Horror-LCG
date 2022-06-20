using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CardInput : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
    {
        [Inject] protected readonly CardShowerManager cardShowerManager;
        [Inject] protected readonly CardShowerPresenter cardShowerPresenter;
        [Inject] protected readonly InteractableAudio audioInteractable;
        [SerializeField] protected CardView cardView;

        /*******************************************************************/
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            audioInteractable.HoverOnSound();
            cardView.PointerEnter();
            cardShowerPresenter.AddShowableAndShow(cardView);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            cardView.PointerExit();
            cardShowerPresenter.RemoveShowableAndHide(cardView);
        }

        void IDropHandler.OnDrop(PointerEventData eventData)
        {
            if (cardShowerManager.CheckIsShow(cardView)) return;
            cardView.PointerEnter();
        }
    }
}
