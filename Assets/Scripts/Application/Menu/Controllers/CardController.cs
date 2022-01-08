using UnityEngine;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
    {
        [Inject] private readonly CardShowerPresenter cardShowerPresenter;
        [Inject] private readonly CardShowerManager cardShowerManager;
        [SerializeField, Required] protected CardView cardView;

        /*******************************************************************/
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
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
            cardShowerPresenter.AddShowableAndShow(cardView);
        }
    }
}
