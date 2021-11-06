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
            Sequence sequence = DOTween.Sequence().Append(showCard.MoveAnimation(selector.PlaceHolderPosition))
                .Append(selector.SetImageAnimation());

            if (!showCard.IsShowing)
            {
                CardView cardView = cardManager.GetInvestigatorCard(investigatorId);
                showCard.Set(cardView);
                sequence.Prepend(showCard.transform.DOScale(1, ViewValues.FAST_TIME));
            }
            sequence.Play();
        }

        public void AddCard(CardSelectorView selector, string cardId)
        {
            cardSelectorScroll.AutoFocus(selector.SelectorTransform, out Vector2 selectorFinalPosition);
            Sequence sequence = DOTween.Sequence().Append(showCard.MoveAnimation(selectorFinalPosition));

            if (!showCard.IsShowing)
            {
                CardView cardView = cardManager.GetDeckCard(cardId);
                showCard.Set(cardView);
                sequence.Prepend(showCard.transform.DOScale(1, ViewValues.FAST_TIME));
            }
            sequence.Play();
        }

        public void RemoveCard(string cardId)
        {
            cardsScroll.AutoFocus(cardManager.GetDeckCard(cardId).transform, out Vector2 cardPosition);
            showCard.MoveAnimation(cardPosition).OnComplete(ReShow);

            void ReShow()
            {
                if (!showCard.IsShowing) return;
                showCard.Set();
                showCard.ShowAnimation();
            }
        }
    }
}
