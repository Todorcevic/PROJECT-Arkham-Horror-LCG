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
        [Inject(Id = "CardsSelector")] private readonly ScrollRect cardSelectorScroll;
        [Inject(Id = "MidZone")] private readonly ScrollRect cardsScroll;

        /*******************************************************************/
        public void AddInvestigator(InvestigatorSelectorView selector, string investigatorId)
        {
            cardShower.Move(selector.PlaceHolderPosition);
            selector.SetImageAnimation();
        }

        public void AddCard(CardSelectorView selector, string cardId)
        {
            cardSelectorScroll.AutoFocus(selector.SelectorTransform, out Vector2 selectorFinalPosition);
            cardShower.Move(selectorFinalPosition);
        }

        public void RemoveCard(string cardId)
        {
            cardsScroll.AutoFocus(cardManager.GetDeckCard(cardId).transform, out Vector2 cardPosition);
            cardShower.Move(cardPosition);
        }
    }
}
