using Arkham.EventData;
using Arkham.Interactors;
using Arkham.Repositories;
using Arkham.Services;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class CardAddPresenter : IInitializable, ICardAddPresenter
    {
        [Inject(Id = "CardPlaceHolderZone")] public RectTransform placeHolderZone;
        [Inject] private readonly ICardAddedEvent addCardEvent;
        [Inject] private readonly ICardSelectorsManager cardSelectorsManager;
        [Inject] private readonly IImageCardsManager imageCards;
        [Inject] private readonly ICardInfo cardInfo;
        [Inject] private readonly IInvestigatorSelectedInfo currentInvestigator;

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
            selector.SetName(cardInfo.Get(cardId).Real_name);
            selector.SetTransform(placeHolderZone);
        }

        private void SetQuantity(CardSelectorView selector)
        {
            int quantity = currentInvestigator.Info.GetAmountOfThisCardInDeck(selector.Id);
            selector.SetQuantity(quantity);
        }
    }
}
