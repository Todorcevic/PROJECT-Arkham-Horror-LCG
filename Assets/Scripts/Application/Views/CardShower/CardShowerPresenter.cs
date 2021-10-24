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
        //[Inject(Id = "CardSelectorZone")] private readonly RectTransform cardSelectorZone;
        //[Inject(Id = "MidZone")] private readonly RectTransform cardZone;
        [Inject(Id = "InvestigatorsSelector")] private readonly PlaceHoldersZone investigatorsSelectorZone;
        [Inject(Id = "Cards")] private readonly PlaceHoldersZone cardsZone;
        [Inject(Id = "CardsSelector")] private readonly PlaceHoldersZone cardsSelectorZone;


        public ShowCard LastShowCard { get; private set; }

        /*******************************************************************/

        public ShowCard SetAndShow(CardShowerDTO showableCard)
        {
            Sprite frontImage = imageCards.GetSprite(showableCard.CardId);
            Sprite backImage = imageCards.GetBackSprite(showableCard.CardId);
            ShowCard showCard = showCards.Find(s => !s.isActiveAndEnabled);
            showCard.Active(showableCard, frontImage, backImage);
            showCard.ShowAnimation(showableCard.FinalPosition);
            LastShowCard = showCard;
            return showCard;
        }

        public void HideAllShowCards() =>
            showCards.FindAll(showCard => showCard.IsActive && !showCard.IsMoving).ForEach(showCard => showCard.Hide());

        public void MoveCard() => LastShowCard?.MoveAnimation(cardsSelectorZone.transform.position);

        public void RemoveCard() => LastShowCard?.MoveAnimation(cardsZone.transform.position);

        public void MoveInvestigator(InvestigatorSelectorView selector) =>
            LastShowCard.MoveAnimation(selector.PlaceHolderPosition).OnComplete(() => selector.SetImageAnimation());
    }
}