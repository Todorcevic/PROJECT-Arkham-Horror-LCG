using UnityEngine;
using Zenject;
using UnityEngine.UI;

namespace Arkham.Application.MainMenu
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
            IShowable showableCard = cardManager.GetInvestigatorCard(investigatorId);
            Move(showableCard, selector.SensorPosition);
            selector.SetImageAnimation();
        }

        public void AddCard(CardSelectorView selector, string cardId)
        {
            cardSelectorScroll.AutoFocus(selector.SelectorTransform, out Vector2 selectorFinalPosition);
            IShowable showableCard = cardManager.GetDeckCard(cardId);
            Move(showableCard, selectorFinalPosition);
        }

        public void RemoveCard(string cardId)
        {
            cardsScroll.AutoFocus(cardManager.GetDeckCard(cardId).transform, out Vector2 cardPosition);
            IShowable showableCard = cardSelectorManager.GetSelectorByCardIdOrEmpty(cardId);
            Move(showableCard, cardPosition);
        }

        public void ReshowCardDeck(string cardId)
        {
            IShowable showableCard = cardManager.GetDeckCard(cardId);
            if (showableCard.MustReshow) AddShowableAndShow(showableCard);
        }

        public void ReshowCardSelector(string cardId)
        {
            IShowable showableCard = cardSelectorManager.GetSelectorByCardIdOrEmpty(cardId);
            if (showableCard.MustReshow) AddShowableAndShow(showableCard);
        }

        public void ReshowCardInvestigator(string cardId)
        {
            IShowable showablewCard = cardManager.GetInvestigatorCard(cardId);
            if (showablewCard.MustReshow) AddShowableAndShow(showablewCard);
        }

        public void AddShowableAndShow(IShowable showableCard)
        {
            ShowCardView showCard = cardShowerManager.GetVoidShowCard();
            showCard.SetShowableCard(showableCard);
            showCard.ShowAnimation(showableCard.ShowPosition);
        }

        public void RemoveShowableAndHide(IShowable showableCar)
        {
            foreach (ShowCardView showCard in cardShowerManager.GetAllThisShowCards(showableCar))
            {
                showCard.Clean();
                showCard.Hide();
            }
        }

        public void RemoveAllShowableExcept(string cardId)
        {
            IShowable showableCard = cardManager.GetInvestigatorCard(cardId);
            foreach (ShowCardView showCard in cardShowerManager.GetAllMinusThis(showableCard))
            {
                showCard.Clean();
                showCard.Hide();
            }
        }

        private void Move(IShowable showableCard, Vector2 positionToMove)
        {
            ShowCardView showCard = cardShowerManager.GetThisShowCard(showableCard);
            showCard.Clean();
            showCard.MoveAnimation(positionToMove);
        }
    }
}
