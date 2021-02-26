using Arkham.Components;
using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Models;
using Arkham.Views;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkham.Presenters
{
    public class CardSelectorPresenter : ICardSelectorPresenter
    {
        [Inject(Id = "CardsSelector")] private readonly ISelectorsManager selectorsManager;
        [Inject(Id = "DecksManager")] private readonly ICardsManager cardsManager;
        [Inject] private readonly IDeckBuilderInteractor deckBuilderInteractor;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly IInvestigatorInfoInteractor investigatorInfoInteractor;
        [Inject] private readonly ICardInfoInteractor cardInfoInteractor;
        [Inject] private readonly IImagesCard imageCards;

        public List<ICardSelectorView> Selectors => selectorsManager.Selectors<ICardSelectorView>();

        /*******************************************************************/
        public void Init()
        {
            deckBuilderInteractor.DeckCardAdded += AddCard;
            deckBuilderInteractor.DeckCardRemoved += RemoveCard;
            investigatorSelectorInteractor.InvestigatorSelectedChanged += ShowAllCards;
        }

        private void AddCard(string cardId)
        {
            SetCardInEmptySelector(cardId);
        }

        private void RemoveCard(string cardId)
        {
        }

        private void ShowAllCards(string investigatorId)
        {
            CleanAllSelectors();
            foreach (string cardId in investigatorInfoInteractor.GetFullDeck(investigatorId))
                SetCardInEmptySelector(cardId);
        }

        private void SetCardInEmptySelector(string cardId)
        {
            ICardSelectorView selector = selectorsManager.GetEmptySelector<ICardSelectorView>();
            Sprite spriteCard = imageCards.GetSprite(cardId);
            selector.SetSelector(cardId, spriteCard);
            selector.ActiveSelector(cardId != null);
            selector.SetName(cardInfoInteractor.GetCardInfo(cardId).Name);
            int quantity = investigatorInfoInteractor.GetThisCardAmountInDeck(investigatorSelectorInteractor.InvestigatorSelected, cardId);
            selector.SetQuantity(quantity);
        }

        private void CleanAllSelectors()
        {
            foreach (ICardSelectorView selector in selectorsManager.GetAllFilledSelectors<ICardSelectorView>())
            {
                selector.SetSelector(null);
                selector.ActiveSelector(false);
            }
        }
    }
}
