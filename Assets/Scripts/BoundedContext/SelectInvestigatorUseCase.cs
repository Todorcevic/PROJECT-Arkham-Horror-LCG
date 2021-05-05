using Arkham.Model;
using Arkham.Views;
using System.Collections.Generic;
using Zenject;

namespace Arkham.UseCases
{
    public class SelectInvestigatorUseCase
    {
        [Inject] private readonly Selector selector;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly DeckCardVisibilityPresenter cardVisibility;
        [Inject] private readonly CardsQuantityView cardQuantity;
        [Inject] private readonly InvestigatorAvatarView investigatorAvatar;
        [Inject] private readonly CardSelectorPresenter cardSelector;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;

        private string AmountCards => selector.InvestigatorSelected?.AmountCardsSelected.ToString();
        private string DeckSize => selector.InvestigatorSelected?.DeckBuilding.DeckSize.ToString();

        /*******************************************************************/
        public void Select(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            Select(investigator);
        }

        public void SelectLead() => Select(selector.Lead);

        private void Select(Investigator investigator)
        {
            UpdateModel(investigator);
            UpdateView(investigator);
        }

        private void UpdateModel(Investigator investigator) => selector.SetCurrentInvestigator(investigator);

        private void UpdateView(Investigator investigator)
        {
            investigatorSelector.SelectInvestigator(investigator?.Id);
            investigatorAvatar.ShowInvetigator(investigator?.Id);
            cardQuantity.Refresh(AmountCards, DeckSize);
            cardVisibility.RefreshCardsSelectability();
            cardVisibility.RefreshCardsVisibility();
            cardSelector.ShowAllCards(CreateDTOList(investigator));
        }

        private List<CardRowDTO> CreateDTOList(Investigator investigator)
        {
            List<CardRowDTO> allCardRow = new List<CardRowDTO>();
            if (investigator == null) return allCardRow;
            foreach (Card card in investigator?.FullDeck)
                allCardRow.Add(new CardRowDTO(card.Id, card.Real_name, investigator.GetAmountOfThisCardInDeck(card)));
            return allCardRow;
        }
    }
}
