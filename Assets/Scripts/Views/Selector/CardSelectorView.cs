using Sirenix.OdinInspector;
using UnityEngine;
using TMPro;
using Arkham.Presenters;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Zenject;
using Arkham.EventData;
using Arkham.Interactors;

namespace Arkham.Views
{
    public class CardSelectorView : SelectorView, ICardSelector, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly IRemoveCard removeCard;
        [Inject] private readonly IClickableCards clickableCards;
        [SerializeField, Required, ChildGameObjectsOnly] private Image background;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI cardName;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI quantity;
        [SerializeField, Required, ChildGameObjectsOnly] private CardSelectorEffects effects;

        public bool IsClickable { get; set; } = true;
        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!clickableCards.IsClickable(Id)) return;
            effects.ClickEffect();
            removeCard.RemoveDeckCard(Id);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => effects.HoverOnEffect();

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => effects.HoverOffEffect();

        public void SetName(string cardName) => this.cardName.text = cardName;

        public void SetQuantity(int amount) => quantity.text = (amount <= 1) ? string.Empty : "x" + amount.ToString();
    }
}
