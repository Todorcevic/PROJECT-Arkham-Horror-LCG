using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class DeckCardPresenter
    {
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly CardSelectionInteractor cardSelectionFilter;
        [Inject] private readonly CardVisibilityInteractor visibilityService;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly CardShowerPresenter cardShower;
        [Inject] private readonly CardXpCostInteractor xpInteractor;

        /*******************************************************************/
        public void RefreshCardsVisibility()
        {
            foreach (DeckCardView cardView in cardsManager.DeckList)
            {
                bool canBeShowed = visibilityService.CanThisCardBeShowed(cardView.Id, investigatorSelectorManager.CurrentInvestigatorId);
                if (!canBeShowed) cardShower.HoveredOff();
                cardView.Show(canBeShowed);
            }
        }

        public void RefreshCardsSelectability()
        {
            foreach (DeckCardView cardView in cardsManager.DeckList)
            {
                bool canBeSelected = cardSelectionFilter.CanThisCardBeSelected(cardView.Id, investigatorSelectorManager.CurrentInvestigatorId);
                cardView.Activate(canBeSelected);
                SetXp(cardView);
            }
        }

        public void RefresQuantity()
        {
            foreach (DeckCardView cardView in cardsManager.DeckList)
            {
                Card card = cardRepository.Get(cardView.Id);
                int quantity = investigatorRepository.AmountLeftOfThisCard(card);
                cardView.SetQuantity(quantity);
            }
        }

        public void SetQuantity(Card card)
        {
            int quantity = investigatorRepository.AmountLeftOfThisCard(card);
            cardsManager.GetDeckCard(card.Id).SetQuantity(quantity);
        }

        private void SetXp(DeckCardView cardView)
        {
            int xpCost = xpInteractor.XpPayCost(cardView.Id, investigatorSelectorManager.CurrentInvestigatorId);
            cardView.SetXpCost(xpCost);
        }
    }
}
