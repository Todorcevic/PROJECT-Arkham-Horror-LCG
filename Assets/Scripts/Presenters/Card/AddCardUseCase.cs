using Arkham.EventData;
using Arkham.Interactors;
using Arkham.Services;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class AddCardUseCase : IInitializable, IAddCardUseCase
    {
        [Inject(Id = "CardPlaceHolderZone")] public RectTransform placeHolderZone;
        [Inject] private readonly IAddCardEvent addCardEvent;
        [Inject] private readonly ICardSelectorsManager cardSelectorsManager;
        [Inject] private readonly IImageCardsManager imageCards;
        [Inject] private readonly ICardInfoInteractor cardInfoInteractor;
        [Inject] private readonly ICurrentInvestigatorInteractor currentInvestigator;

        /*******************************************************************/
        public void Initialize() => addCardEvent.AddAction(SetCardInSelector);

        /*******************************************************************/
        public void SetCardInSelector(string cardId)
        {
            CardSelectorView selector = cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardId);
            if (selector.IsEmpty) ActivateSelector(selector, cardId);
            SetQuantity(selector);
        }

        private void ActivateSelector(CardSelectorView selector, string cardId)
        {
            selector.SetSelector(cardId, imageCards.GetSprite(cardId));
            selector.SetName(cardInfoInteractor.GetRealName(cardId));
            selector.SetTransform(placeHolderZone);
        }

        private void SetQuantity(CardSelectorView selector)
        {
            int quantity = currentInvestigator.GetAmountOfThisCardInDeck(selector.Id);
            selector.SetQuantity(quantity);
        }
    }
}
