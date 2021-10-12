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

        public void HoveredOn(CardShowerDTO showableCard)
        {
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

        public void HoveredOff()
        {
            if (!LastShowCard.IsMoving)
            {
                LastShowCard?.Hide();
                showCards.FindAll(showCard => !showCard.IsMoving && showCard.IsActive).ForEach(s => s.Hide());
            }
        }

        public void MoveCard() => LastShowCard?.MoveAnimation(cardSelectorZone.position);

        public void RemoveCard() => LastShowCard?.MoveAnimation(cardZone.position);

        public Tween MoveInvestigator(Vector2 positionToMove) => LastShowCard.MoveAnimation(positionToMove);
    }
}