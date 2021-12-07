using UnityEngine;
using DG.Tweening;
using Zenject;
using Arkham.Application;
using UnityEngine.UI;

namespace Arkham.Services
{
    public class MultiAnimator
    {
        [Inject] private readonly CardShower cardShower;
        [Inject] private readonly CardsManager cardManager;
        [Inject] private readonly CardSelectorsManager cardSelectorManager;
        [Inject(Id = "CardsSelector")] private readonly ScrollRect cardSelectorScroll;
        [Inject(Id = "MidZone")] private readonly ScrollRect cardsScroll;

        /*******************************************************************/
        public void AddInvestigator(InvestigatorSelectorView selector, string investigatorId)
        {
            IShowable showablewCard = cardManager.GetInvestigatorCard(investigatorId);
            cardShower.Move(showablewCard, selector.SensorPosition);
            selector.SetImageAnimation();
        }

        public void AddCard(CardSelectorView selector, string cardId)
        {
            cardSelectorScroll.AutoFocus(selector.SelectorTransform, out Vector2 selectorFinalPosition);
            IShowable showablewCard = cardManager.GetDeckCard(cardId);
            cardShower.Move(showablewCard, selectorFinalPosition);
        }

        public void RemoveCard(string cardId)
        {
            cardsScroll.AutoFocus(cardManager.GetDeckCard(cardId).transform, out Vector2 cardPosition);
            IShowable showablewCard = cardSelectorManager.GetSelectorByCardIdOrEmpty(cardId);
            cardShower.Move(showablewCard, cardPosition);
        }

        public void ReshowCardDeck(string cardId)
        {
            IShowable showablewCard = cardManager.GetDeckCard(cardId);
            if (showablewCard.MustReshow) cardShower.AddShowableAndShow(showablewCard);
        }

        public void ReshowCardSelector(string cardId)
        {
            IShowable showablewCard = cardSelectorManager.GetSelectorByCardIdOrEmpty(cardId);
            if (showablewCard.MustReshow) cardShower.AddShowableAndShow(showablewCard);
        }

        public void ReshowCardInvestigator(string cardId)
        {
            IShowable showablewCard = cardManager.GetInvestigatorCard(cardId);
            if (showablewCard.MustReshow) cardShower.AddShowableAndShow(showablewCard);
        }
    }
}
