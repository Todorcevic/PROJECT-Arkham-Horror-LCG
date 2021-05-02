using Arkham.Model;
using UnityEngine;
using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class CardRemovePresenter : IInitializable
    {
        [Inject(Id = "CardSelectorZone")] public RectTransform selectorsZone;
        [Inject] private readonly RemoveCardEventDomain removeCardEvent;
        [Inject] private readonly ICardSelectorsManager cardSelectorsManager;
        [Inject] private readonly Selector selector;

        /*******************************************************************/
        public void Initialize() => removeCardEvent.Subscribe(RemoveCardInSelector);

        /*******************************************************************/
        private void RemoveCardInSelector(string cardId)
        {
            CardSelectorView selector = cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardId);
            if (SetQuantityAndGetIt(selector, cardId) <= 0)
                DesactivateSelector(selector);
        }

        private int SetQuantityAndGetIt(CardSelectorView selector, string cardId)
        {
            int quantity = this.selector.InvestigatorSelected.GetAmountOfThisCardInDeck(cardId);
            selector.SetQuantity(quantity);
            return quantity;
        }

        private void DesactivateSelector(CardSelectorView selector)
        {
            selector.SetSelector(null);
            selector.SetTransform(selectorsZone);
        }
    }
}
