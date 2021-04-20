using Arkham.EventData;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class CardShowerPresenter : IInitializable, ICardShowerPresenter
    {
        private Task moveAnimation;
        private CardShowerDTO currentShowableCard;
        [Inject] private readonly IAddInvestigatorEvent addInvestigatorEvent;
        [Inject] private readonly IAddCardEvent addCardEvent;
        [Inject] private readonly IRemoveCardEvent removeCardEvent;
        [Inject] private readonly IImageCardsManager imageCards;
        [Inject] private readonly ICardShower cardShower;
        [Inject(Id = "CardSelectorZone")] private readonly RectTransform cardSelector;
        [Inject(Id = "MidZone")] private readonly RectTransform cardZone;

        /*******************************************************************/
        public void Initialize()
        {
            addInvestigatorEvent.AddAction((_) => Hide());
            addCardEvent.AddAction(AddCard);
            removeCardEvent.AddAction(RemoveCard);
        }

        public async void Show(CardShowerDTO showableCard)
        {
            currentShowableCard = showableCard;
            if (moveAnimation != null) await moveAnimation;
            if (currentShowableCard == null) return;
            SetAndShowCard(showableCard);
        }

        private void SetAndShowCard(CardShowerDTO showableCard)
        {
            cardShower.MoveShowCard(showableCard.Position);
            cardShower.ActiveFrontImage(imageCards.GetSprite(showableCard.CardId), showableCard.ImageColor);
            cardShower.ActiveBackImage(imageCards.GetBackSprite(showableCard.CardId), showableCard.ImageColor);
            cardShower.ShowAnimation(showableCard.FinalPosition);
        }

        public void Hide()
        {
            currentShowableCard = null;
            cardShower.Hide();
        }

        private void AddCard(string cardId)
        {
            moveAnimation = cardShower.MoveAnimation(cardSelector.position);
            Reshow();
        }

        private void RemoveCard(string cardId)
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