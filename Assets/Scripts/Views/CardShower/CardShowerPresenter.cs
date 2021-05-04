using Arkham.Services;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class CardShowerPresenter
    {
        private Task moveAnimation;
        private CardShowerDTO currentShowableCard;
        [Inject] private readonly ICardImage imageCards;
        [Inject] private readonly CardShowerView cardShower;
        [Inject(Id = "CardSelectorZone")] private readonly RectTransform cardSelectorZone;
        [Inject(Id = "MidZone")] private readonly RectTransform cardZone;

        /*******************************************************************/
        public async void HoveredOn(CardShowerDTO showableCard)
        {
            currentShowableCard = showableCard;
            if (moveAnimation != null) await moveAnimation;
            if (currentShowableCard == null) return;
            Sprite frontImage = imageCards.GetSprite(showableCard.CardId);
            Sprite backImage = imageCards.GetBackSprite(showableCard.CardId);
            cardShower.SetShowCard(showableCard.Position, frontImage, backImage);
            cardShower.ShowAnimation(showableCard.FinalPosition);
        }

        public void HoveredOff()
        {
            currentShowableCard = null;
            cardShower.Hide();
        }

        public Task AddInvestigatorAnimation(Vector2 placeHolderPosition) =>
            moveAnimation = cardShower.MoveAnimation(placeHolderPosition);

        public async void AddCardAnimation()
        {
            moveAnimation = cardShower.MoveAnimation(cardSelectorZone.position);
            await moveAnimation;
            Reshow();
        }

        public async void RemoveCardAnimation()
        {
            moveAnimation = cardShower.MoveAnimation(cardZone.position);
            await moveAnimation;
            Reshow();
        }

        private void Reshow()
        {
            cardShower.Hide();
            if (currentShowableCard != null)
                HoveredOn(currentShowableCard);
        }
    }
}