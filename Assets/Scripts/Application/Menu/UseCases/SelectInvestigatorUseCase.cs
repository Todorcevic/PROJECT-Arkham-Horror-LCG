using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class SelectInvestigatorUseCase
    {
        [Inject] private readonly SelectorsRepository selector;
        [Inject] private readonly InvestigatorsRepository investigatorRepository;
        [Inject] private readonly DeckCardPresenter cardVisibility;
        [Inject] private readonly CardsQuantityPresenter cardQuantityPresenter;
        [Inject] private readonly ButtonsPresenter buttonsPresenter;
        [Inject] private readonly CardSelectorPresenter cardSelector;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly AvatarPresenter avatarPresenter;

        /*******************************************************************/
        public void SelectLead() => Select(selector.Lead?.Id);

        public void Select(string investigatorId)
        {
            if (investigatorSelectorsManager.InvestigatorSelected == investigatorId) return;
            Investigator investigator = investigatorRepository.Get(investigatorId);
            avatarPresenter.SetAvatar(investigator);
            buttonsPresenter.AutoActivateRetireButton(investigator);
            investigatorSelectorsManager.SelectInvestigator(investigatorId);
            cardQuantityPresenter.Update(investigator);
            cardVisibility.RefreshCardsSelectability();
            cardVisibility.RefreshCardsVisibility();
            cardSelector.ShowAllCards(investigator);
            cardSelector.SetCanBeRemovedInSelectors(investigatorId);
        }
    }
}
