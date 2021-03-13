using Arkham.EventData;
using Arkham.Interactors;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Views
{
    public class CardSelectorController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly IRemoveCard removeCard;
        [Inject] private readonly IClickableCards clickableCards;

        [Title("RESOURCES")]
        [SerializeField, Required] private CardSelectorView selectorView;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!clickableCards.IsClickable(selectorView.Id)) return;
            selectorView.Effects.ClickEffect();
            removeCard.RemoveDeckCard(selectorView.Id);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => selectorView.Effects.HoverOnEffect();

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => selectorView.Effects.HoverOffEffect();
    }
}
