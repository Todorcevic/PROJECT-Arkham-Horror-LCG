﻿using Arkham.Model;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Application
{
    public class InvestigatorsCardPresenter
    {
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly InvestigatorSelectionInteractor investigatorSelectionFilter;
        [Inject] private readonly CardVisibilityInteractor visibilityService;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject] private readonly InvestigatorRepository investigatorRepository;

        /*******************************************************************/
        public void RefreshInvestigatorsVisibility()
        {
            foreach (CardView cardView in cardsManager.InvestigatorList)
            {
                bool canBeShowed = visibilityService.CanThisCardBeShowed(cardView.Id, investigatorSelectorManager.CurrentInvestigatorId);
                cardView.Show(canBeShowed);
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
