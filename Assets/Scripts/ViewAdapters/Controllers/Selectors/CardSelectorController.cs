using Arkham.EventData;
using Arkham.Interactors;
using Arkham.Views;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public class CardSelectorController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly IRemoveCard removeCard;
        [Inject] private readonly IClickableCards clickableCards;
        [Inject] private readonly IShowCard showCard;

        [Title("RESOURCES")]
        [SerializeField, Required] private CardSelectorView selectorView;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!clickableCards.IsClickable(selectorView.Id)) return;
            selectorView.ClickEffect();
            removeCard.RemoveDeckCard(selectorView.Id);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            selectorView.HoverOnEffect();
            showCard.ShowInRightSide(selectorView);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            selectorView.HoverOffEffect();
            showCard.HidePreviewCard();
        }
    }
}
