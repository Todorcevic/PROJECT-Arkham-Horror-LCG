using Arkham.Services;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkham.Application
{
    public class CardShowerPresenter
    {
        [Inject] private readonly ICardImage imageCards;
        [Inject] private readonly List<ShowCard> showCards;
        [Inject(Id = "CardSelectorZone")] private readonly RectTransform cardSelectorZone;
        [Inject(Id = "MidZone")] private readonly RectTransform cardZone;

        public ShowCard LastShowCard { get; private set; }

        /*******************************************************************/
        private ShowCard GetNewShowCard()
        {
            ShowCard showCard = showCards.Find(s => !s.isActiveAndEnabled);
            showCard.gameObject.SetActive(true);
            LastShowCard = showCard;
            return showCard;
        }

        public ShowCard HoveredOn(CardShowerDTO showableCard)
        {
            ShowCard showCard = GetNewShowCard();
            MoveShowCard();
            SetShowCard();
            showCard.ShowAnimation(showableCard.FinalPosition);
            return showCard;

            void MoveShowCard() => showCard.transform.position = showableCard.Position;

            void SetShowCard()
            {
                Sprite frontImage = imageCards.GetSprite(showableCard.CardId);
                Sprite backImage = imageCards.GetBackSprite(showableCard.CardId);
                showCard.Active(showableCard.CardId, frontImage, backImage);
            }
        }

        public void HoveredOff()
        {
            if (!DOTween.IsTweening(LastShowCard))
            {
                LastShowCard?.Hide();
            }
        }

        public void MoveCard() => LastShowCard?.MoveAnimation(cardSelectorZone.position).SetId(LastShowCard);

        public void RemoveCard() => LastShowCard?.MoveAnimation(cardZone.position).SetId(LastShowCard);

        public Tween MoveInvestigator(Vector2 positionToMove) => LastShowCard.MoveAnimation(positionToMove).SetId(LastShowCard);
    }
}