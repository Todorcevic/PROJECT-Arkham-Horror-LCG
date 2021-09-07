using Arkham.Services;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkham.Application
{
    public class CardShowerPresenter
    {
        CardShowerDTO current;
        [Inject] private readonly ICardImage imageCards;
        [Inject] private readonly List<ShowCard> showCards;
        [Inject(Id = "CardSelectorZone")] private readonly RectTransform cardSelectorZone;
        [Inject(Id = "MidZone")] private readonly RectTransform cardZone;

        /*******************************************************************/
        private ShowCard GetNewShowCard()
        {
            ShowCard showCard = showCards.Find(s => !s.isActiveAndEnabled);
            showCard.gameObject.SetActive(true);
            return showCard;
        }

        private ShowCard GetShowedShowCard() => showCards.Find(showCard => showCard.isActiveAndEnabled && !DOTween.IsTweening(showCard));

        public void HoveredOn(CardShowerDTO showableCard)
        {
            current = showableCard;
            ShowCard showCard = GetNewShowCard();
            MoveShowCard();
            SetShowCard();
            showCard.ShowAnimation(showableCard.FinalPosition);

            void MoveShowCard() => showCard.transform.position = showableCard.Position;

            void SetShowCard()
            {
                Sprite frontImage = imageCards.GetSprite(showableCard.CardId);
                Sprite backImage = imageCards.GetBackSprite(showableCard.CardId);
                showCard.Active(showableCard.CardId, frontImage, backImage);
            }
        }

        public void HoveredOff() => GetShowedShowCard()?.Hide();

        public void MoveCard()
        {
            ShowCard showCard = GetShowedShowCard();
            showCard.MoveAnimation(cardSelectorZone.position).SetId(showCard);
            HoveredOn(current);
        }

        public void RemoveCard()
        {
            ShowCard showCard = GetShowedShowCard();
            showCard.MoveAnimation(cardZone.position).SetId(showCard);
            HoveredOn(current);
        }

        public Tween MoveInvestigator(Vector2 positionToMove)
        {
            ShowCard showCard = GetShowedShowCard();
            HoveredOn(current);
            return showCard.MoveAnimation(positionToMove).SetId(showCard);
        }
    }
}