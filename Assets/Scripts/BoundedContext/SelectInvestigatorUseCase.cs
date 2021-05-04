using Arkham.Model;
using Arkham.Views;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Adapter
{
    public class SelectInvestigatorUseCase
    {
        [Inject] private readonly Selector selectorRepository;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly DeckCardVisibilityPresenter cardVisibility;
        [Inject] private readonly CardsQuantityPresenter cardsQuantity;
        [Inject] private readonly InvestigatorAvatarPresenter investigatorAvatar;
        [Inject] private readonly CardSelectorPresenter cardSelector;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;

        /*******************************************************************/
        public void Select(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            Select(investigator);
        }

        public void SelectLead() => Select(selectorRepository.Lead);

        public void SelectCurrentOrLead() => Select(selectorRepository.InvestigatorSelected ?? selectorRepository.Lead);

        private void Select(Investigator investigator)
        {
            UpdateModel(investigator);
            UpdateView(investigator);
        }

        private void UpdateModel(Investigator investigator) => selectorRepository.InvestigatorSelected = investigator;

        private void UpdateView(Investigator investigator)
        {
            investigatorSelector.SelectInvestigator(investigator?.Id);
            investigatorAvatar.ShowInvetigator(investigator?.Id);
            cardsQuantity.Refresh();
            cardVisibility.RefreshCardsVisibility();
            cardSelector.ShowAllCards(CreateDTOList(investigator));
        }

        private List<CardRowDTO> CreateDTOList(Investigator investigator)
        {
            List<CardRowDTO> allCardRow = new List<CardRowDTO>();
            if (investigator == null) return allCardRow;
            foreach (Card card in investigator?.FullDeck)
                allCardRow.Add(new CardRowDTO(card.Code, card.Real_name, investigator.GetAmountOfThisCardInDeck(card)));
            return allCardRow;
        }
    }
}
