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

        /*******************************************************************/
        private ShowCard GetShowCard()
        {
            ShowCard showCard = showCards.Find(s => !s.isActiveAndEnabled);
            showCard.gameObject.SetActive(true);
            return showCard;
        }

        private ShowCard GetShowCardById(string id) => showCards.Find(showCard => showCard.Id == id);

        public void HoveredOn(CardShowerDTO showableCard)
        {
            ShowCard showCard = GetShowCard();
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

        public void HoveredOff(string id) => GetShowCardById(id)?.Hide();

        public void MoveCard(string id) => GetShowCardById(id).MoveAnimation(cardSelectorZone.position);

        public void RemoveCard(string id) => GetShowCardById(id).MoveAnimation(cardZone.position);

        public Tween MoveInvestigator(string id, Vector2 positionToMove) => GetShowCardById(id).MoveAnimation(positionToMove);

    }
}