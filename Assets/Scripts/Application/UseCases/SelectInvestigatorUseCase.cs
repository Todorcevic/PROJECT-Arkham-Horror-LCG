using Arkham.Model;
using UnityEngine;
using Zenject;

namespace Arkham.Application
{
    public class SelectInvestigatorUseCase
    {
        [Inject] private readonly SelectorRepository selector;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly DeckCardPresenter cardVisibility;
        [Inject] private readonly CardsQuantityView cardQuantity;
        [Inject] private readonly InvestigatorAvatarView investigatorAvatar;
        [Inject] private readonly CardSelectorPresenter cardSelector;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;
        [Inject] private readonly CardsManager investigatorCardsManager;

        /*******************************************************************/
        public void SelectLead() => Select(selector.Lead?.Id);

        public void Select(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            if (investigator != null)
            {
                Sprite imageCard = investigatorCardsManager.GetSpriteCard(investigator?.Id);
                investigatorAvatar.SetAvatar(imageCard, investigator.PhysicTrauma, investigator.MentalTrauma, investigator.Xp);
            }
            investigatorSelector.SelectInvestigator(investigatorId);
            cardQuantity.Refresh(investigator);
            cardVisibility.RefreshCardsSelectability();
            cardVisibility.RefreshCardsVisibility();
            cardSelector.ShowAllCards(investigator);
            cardSelector.SetCanBeRemovedInSelectors(investigatorId);
        }
    }
}
