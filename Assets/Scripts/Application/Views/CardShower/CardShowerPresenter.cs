using UnityEngine;
using Zenject;
using UnityEngine.UI;
using Arkham.Services;

namespace Arkham.Application
{
    public class CardShowerPresenter
    {
        [Inject] private readonly CardShowerManager cardShowerManager;
        [Inject] private readonly CardsManager cardManager;
        [Inject] private readonly CardSelectorsManager cardSelectorManager;
        [Inject(Id = "CardsSelector")] private readonly ScrollRect cardSelectorScroll;
        [Inject(Id = "MidZone")] private readonly ScrollRect cardsScroll;

        /*******************************************************************/
        public void AddInvestigator(InvestigatorSelectorView selector, string investigatorId)
        {
            IShowable showablewCard = cardManager.GetInvestigatorCard(investigatorId);
            Move(showablewCard, selector.SensorPosition);
            selector.SetImageAnimation();
        }

        public void AddCard(CardSelectorView selector, string cardId)
        {
            cardSelectorScroll.AutoFocus(selector.SelectorTransform, out Vector2 selectorFinalPosition);
            IShowable showablewCard = cardManager.GetDeckCard(cardId);
            Move(showablewCard, selectorFinalPosition);
        }

        public void RemoveCard(string cardId)
        {
            cardsScroll.AutoFocus(cardManager.GetDeckCard(cardId).transform, out Vector2 cardPosition);
            IShowable showablewCard = cardSelectorManager.GetSelectorByCardIdOrEmpty(cardId);
            Move(showablewCard, cardPosition);
        }

        public void ReshowCardDeck(string cardId)
        {
            IShowable showablewCard = cardManager.GetDeckCard(cardId);
            if (showablewCard.MustReshow) AddShowableAndShow(showablewCard);
        }

        public void ReshowCardSelector(string cardId)
        {
            IShowable showablewCard = cardSelectorManager.GetSelectorByCardIdOrEmpty(cardId);
            if (showablewCard.MustReshow) AddShowableAndShow(showablewCard);
        }

        public void ReshowCardInvestigator(string cardId)
        {
            IShowable showablewCard = cardManager.GetInvestigatorCard(cardId);
            if (showablewCard.MustReshow) AddShowableAndShow(showablewCard);
        }

        public void AddShowableAndShow(IShowable showableCard)
        {
            ShowCard showCard = cardShowerManager.GetVoidShowCard();
            showCard.SetShowableCard(showableCard);
            showCard.ShowAnimation(showableCard.ShowPosition);
        }

        public void RemoveShowableAndHide(IShowable showableCar)
        {
            foreach (ShowCard showCard in cardShowerManager.GetAllThisShowCards(showableCar))
            {
                showCard.Clean();
                showCard.Hide();
            }
        }

        private void Move(IShowable showableCard, Vector2 positionToMove)
        {
            ShowCard showCard = cardShowerManager.GetThisShowCard(showableCard);
            showCard.Clean();
            showCard.MoveAnimation(positionToMove);
        }
    }
}
