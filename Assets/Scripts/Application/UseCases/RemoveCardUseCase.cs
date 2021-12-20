using Arkham.Model;
using Arkham.Application;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application
{
    public class RemoveCardUseCase
    {
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly ReadyButtonPresenter readyButton;
        [Inject] private readonly DeckCardPresenter deckCardPresenter;
        [Inject] private readonly CardsQuantityView cardQuantity;
        [Inject] private readonly CardSelectorPresenter cardSelector;
        [Inject] private readonly CardShowerPresenter multiAnimator;
        [Inject(Id = "CardsButton")] private readonly ButtonView cardsButton;

        /*******************************************************************/
        public void Remove(string cardId, string investigatorId)
        {
            Card card = cardRepository.Get(cardId);
            Investigator investigator = investigatorRepository.Get(investigatorId);
            UpdateModel(card, investigator);
            UpdateView(card, investigator);
        }

        private void UpdateModel(Card card, Investigator investigator) => investigator.RemoveToDeck(card);

        private void UpdateView(Card card, Investigator investigator)
        {
            multiAnimator.RemoveCard(card.Id);
            cardSelector.SetCardInSelector(card, investigator);
            cardSelector.SetCanBeRemovedInSelectors(investigator.Id);
            deckCardPresenter.RefreshCardsSelectability();
            deckCardPresenter.SetQuantity(card);
            cardQuantity.Refresh(investigator);
            multiAnimator.ReshowCardSelector(card.Id);
            readyButton.AutoActivate();
            cardsButton.ExecuteClick();
        }
    }
}
