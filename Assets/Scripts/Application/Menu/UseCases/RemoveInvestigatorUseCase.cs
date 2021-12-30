﻿using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class RemoveInvestigatorUseCase
    {
        [Inject] private readonly InvestigatorsRepository investigatorRepository;
        [Inject] private readonly SelectorsRepository selectorRepository;
        [Inject] private readonly ReadyButtonPresenter readyButton;
        [Inject] private readonly InvestigatorsCardPresenter investigatorVisibility;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;
        [Inject] private readonly SelectInvestigatorUseCase selectInvestigatorUseCase;
        [Inject(Id = "InvestigatorsButton")] private readonly ButtonView investigatorsButton;

        /*******************************************************************/
        public void Remove(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            if (!selectorRepository.Contains(investigator)) return;
            UpdateModel(investigator);
            UpdateView(investigatorId);
            selectInvestigatorUseCase.SelectLead();
        }

        private void UpdateModel(Investigator investigator) => selectorRepository.Remove(investigator);

        private void UpdateView(string investigatorId)
        {
            investigatorSelector.SetLeadSelector();
            investigatorSelector.RemoveInvestigator(investigatorId);
            investigatorVisibility.RefreshInvestigatorsSelectability();
            readyButton.AutoActivate();
            investigatorsButton.ExecuteClick();
        }
    }
}
