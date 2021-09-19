using Arkham.Model;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Application
{
    public class InvestigatorsCardPresenter
    {
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly InvestigatorSelectionInteractor investigatorSelectionFilter;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly UnlockCardsRepository unlockCardsRepository;
        [Inject(Id = "InputSearch")] private readonly InputFieldView inputSearch;
        [Inject(Id = "VisibilitySwitch")] private readonly SwitchView visibilitySwitchView;

        /*******************************************************************/
        public void RefreshInvestigatorsVisibility()
        {
            foreach (CardView cardView in cardsManager.InvestigatorList)
            {
                Card card = investigatorRepository.Get(cardView.Id).Info;
                cardView.Show(CanbeShowed());

                bool CanbeShowed()
                {
                    if (!card.ContainThisText(inputSearch.CurrentText)) return false;
                    if (visibilitySwitchView.IsOn) return true;
                    if (!unlockCardsRepository.IsThisCardUnlocked(card)) return false;
                    return true;
                }
            }
        }

        public void RefreshInvestigatorsSelectability()
        {
            foreach (CardView cardView in cardsManager.InvestigatorList)
            {
                bool canBeSelected = investigatorSelectionFilter.CanThisCardBeSelected(cardView.Id);
                cardView.Activate(canBeSelected);
            }
        }

        public void InvestigatorStateResolve()
        {
            foreach (Investigator investigator in investigatorRepository.Investigators)
            {
                InvestigatorCardView investigatorView = cardsManager.GetInvestigatorCard(investigator.Id);
                bool hasNoState = investigator.State == InvestigatorState.None;
                investigatorView.UpdatePhysicTrauma(hasNoState ? investigator.PhysicTrauma : 0);
                investigatorView.UpdateMentalTrauma(hasNoState ? investigator.MentalTrauma : 0);
                investigatorView.UpdateXp(hasNoState ? investigator.Xp : 0);
                investigatorView.ShowRetireButton(hasNoState && investigator.IsPlaying);
                investigatorView.ChangeState(investigator.State);
            }
        }
    }
}
