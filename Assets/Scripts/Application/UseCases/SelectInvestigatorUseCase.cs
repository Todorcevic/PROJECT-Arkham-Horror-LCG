using Arkham.Model;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Application
{
    public class SelectInvestigatorUseCase
    {
        [Inject] private readonly Selector selector;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly DeckCardPresenter cardVisibility;
        [Inject] private readonly CardsQuantityView cardQuantity;
        [Inject] private readonly InvestigatorAvatarView investigatorAvatar;
        [Inject] private readonly CardSelectorPresenter cardSelector;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;

        /*******************************************************************/
        public void SelectLead() => Select(selector.Lead?.Id);

        public void Select(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            investigatorSelector.SelectInvestigator(investigatorId);
            investigatorAvatar.ShowInvetigator(investigatorId);
            cardQuantity.Refresh(investigator?.AmountCardsSelected.ToString(), investigator?.DeckBuilding.DeckSize.ToString());
            cardVisibility.RefreshCardsSelectability();
            cardVisibility.RefreshCardsVisibility();
            cardSelector.ShowAllCards(CreateDTOList(investigatorId));
        }

        private List<CardRowDTO> CreateDTOList(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            List<CardRowDTO> allCardRow = new List<CardRowDTO>();
            if (investigator == null) return allCardRow;
            foreach (Card card in investigator?.FullDeck)
                allCardRow.Add(new CardRowDTO(card.Id, card.Real_name, investigator.GetAmountOfThisCardInDeck(card)));
            return allCardRow;
        }
    }
}
