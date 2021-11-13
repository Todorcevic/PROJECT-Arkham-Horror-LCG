using UnityEngine;
using DG.Tweening;
using Arkham.Config;
using Zenject;
using Arkham.Application;
using UnityEngine.UI;

namespace Arkham.Services
{
    public class MultiAnimator
    {
        [Inject] private readonly ShowCard showCard;
        [Inject] private readonly CardsManager cardManager;
        [Inject(Id = "CardsSelector")] private readonly ScrollRect cardSelectorScroll;
        [Inject(Id = "MidZone")] private readonly ScrollRect cardsScroll;

        /*******************************************************************/
        public void AddInvestigator(InvestigatorSelectorView selector, string investigatorId)
        {
            if (!showCard.IsShow)
            {
                CardView cardView = cardManager.GetInvestigatorCard(investigatorId);
                showCard.Set(cardView, withBack: false);
                showCard.transform.localScale = Vector3.one;
            };
            DOTween.Sequence().Append(showCard.MoveAnimation(selector.PlaceHolderPosition))
                .Append(selector.SetImageAnimation());
        }

        public void AddCard(CardSelectorView selector, string cardId)
        {
            cardSelectorScroll.AutoFocus(selector.SelectorTransform, out Vector2 selectorFinalPosition);

            if (!showCard.IsShow)
            {
                CardView cardView = cardManager.GetDeckCard(cardId);
                showCard.Set(cardView);
                showCard.transform.localScale = Vector3.one;
            }
            showCard.MoveAnimation(selectorFinalPosition);
        }

        public void RemoveCard(string cardId)
        {
            cardsScroll.AutoFocus(cardManager.GetDeckCard(cardId).transform, out Vector2 cardPosition);
            showCard.MoveAnimation(cardPosition).OnComplete(ReShow);

            void ReShow()
            {
                if (!showCard.IsShow) return;
                showCard.Set();
                showCard.ShowAnimation();
            }
        }
    }
}
