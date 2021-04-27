using Arkham.EventData;
using Arkham.Interactors;
using Arkham.Services;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class CardShowerPresenter : IInitializable, ICardShowerPresenter
    {
        private Task moveAnimation;
        private CardShowerDTO currentShowableCard;
        [Inject] private readonly ICardAddedEvent addCardEvent;
        [Inject] private readonly ICardRemovedEvent cardRemovedEvent;
        [Inject] private readonly IImageCardsManager imageCards;
        [Inject] private readonly ICardShower cardShower;
        [Inject(Id = "CardSelectorZone")] private readonly RectTransform cardSelectorZone;
        [Inject(Id = "MidZone")] private readonly RectTransform cardZone;

        /*******************************************************************/
        public void Initialize()
        {
            addCardEvent.AddAction(AddCardAnimation);
            cardRemovedEvent.AddAction(RemoveCardAnimation);
        }

        public void Hide()
        {
            currentShowableCard = null;
            cardShower.Hide();
        }

        public async void Show(CardShowerDTO showableCard)
        {
            currentShowableCard = showableCard;
            if (moveAnimation != null) await moveAnimation;
            if (currentShowableCard == null) return;
            Sprite frontImage = imageCards.GetSprite(showableCard.CardId);
            Sprite backImage = imageCards.GetBackSprite(showableCard.CardId);
            cardShower.SetShowCard(showableCard.Position, frontImage, backImage, showableCard.ImageColor);
            cardShower.ShowAnimation(showableCard.FinalPosition);
        }

        public Task AddInvestigatorAnimation(Vector2 placeHolderPosition) =>
            moveAnimation = cardShower.MoveAnimation(placeHolderPosition);

        private void AddCardAnimation(string cardId)
        {
            moveAnimation = cardShower.MoveAnimation(cardSelectorZone.position);
            Reshow();
        }

        private void RemoveCardAnimation(string cardId)
        {
            moveAnimation = cardShower.MoveAnimation(cardZone.position);
            Reshow();
        }

        private void Reshow()
        {
            cardShower.Hide();
            if (currentShowableCard != null) Show(currentShowableCard);
        }
    }
}