using Arkham.Config;
using System.Diagnostics;
using Zenject;

namespace Arkham.Interactors
{
    public class CardSelectorInteractors : ICardSelectorInteractors
    {
        [Inject] private readonly IInvestigatorInfoInteractor investigatorInfoInteractor;
        [Inject] private readonly ICardInfoInteractor cardInfoInteractor;
        [Inject] private readonly ICurrentInvestigator currentInvestigator;

        /*******************************************************************/
        public bool CanThisCardBeSelected(string cardId)
        {
            if (currentInvestigator.Id == null) return false;
            if (currentInvestigator.SelectionIsFull) return false;
            if (!IsThisCardAllowed(cardId)) return false;
            if (IsThisCardWasted(cardId)) return false;
            if (IsThisCardInMax(cardId)) return false;
            return true;
        }

        private bool IsThisCardAllowed(string cardId) => currentInvestigator.AllowedCards.Contains(cardId);

        private bool IsThisCardWasted(string cardId) =>
            cardInfoInteractor.GetQuantity(cardId) - investigatorInfoInteractor.AmountSelectedOfThisCard(cardId) <= 0;

        private bool IsThisCardInMax(string cardId) =>
            currentInvestigator.GetAmountOfThisCardInDeck(cardId) >= GameData.MAX_SIMILARS_CARDS_IN_DECK;
    }
}