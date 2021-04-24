using Arkham.EventData;
using Arkham.Interactors;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class RemoveCardUseCase : IInitializable
    {
        [Inject(Id = "CardSelectorZone")] public RectTransform selectorsZone;
        [Inject] private readonly IRemoveCardEvent removeCardEvent;
        [Inject] private readonly ICardSelectorsManager cardSelectorsManager;
        [Inject] private readonly ICurrentInvestigatorInteractor currentInvestigator;

        /*******************************************************************/
        public void Initialize() => removeCardEvent.AddAction(RemoveCardInSelector);

        /*******************************************************************/
        private void RemoveCardInSelector(string cardId)
        {
            CardSelectorView selector = cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardId);
            if (SetQuantityAndGetIt(selector, cardId) <= 0)
                DesactivateSelector(selector);
        }

        private int SetQuantityAndGetIt(CardSelectorView selector, string cardId)
        {
            int quantity = currentInvestigator.GetAmountOfThisCardInDeck(cardId);
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
