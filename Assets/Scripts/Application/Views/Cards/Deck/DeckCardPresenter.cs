using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class DeckCardPresenter
    {
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly CardSelectionInteractor cardSelectionFilter;
        [Inject] private readonly UnlockCardsRepository unlockCardsRepository;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly CardXpCostInteractor xpInteractor;
        [Inject(Id = "InputSearch")] private readonly InputFieldView inputSearch;
        [Inject(Id = "VisibilitySwitch")] private readonly SwitchView visibilitySwitchView;

        /*******************************************************************/
        private Investigator investigator => investigatorRepository.Get(investigatorSelectorManager.CurrentInvestigatorId);

        public void RefreshCardsVisibility()
        {
            foreach (DeckCardView cardView in cardsManager.DeckList)
            {
                Card card = cardRepository.Get(cardView.Id);
                cardView.Show(CanbeShowed());

                bool CanbeShowed()
                {
                    if (!card.ContainThisText(inputSearch.CurrentText)) return false;
                    if (visibilitySwitchView.IsOn) return true;
                    if (!unlockCardsRepository.IsThisCardUnlocked(card)) return false;
                    if (!cardSelectionFilter.IsThisCardAllowed(card, investigator)) return false;
                    return true;
                }
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
