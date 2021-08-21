﻿using Arkham.Model;
using Arkham.Application;
using Zenject;

namespace Arkham.Application
{
    public class RemoveInvestigatorUseCase
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly Selector selector;
        [Inject] private readonly ReadyButtonPresenter readyButton;
        [Inject] private readonly InvestigatorsCardPresenter investigatorVisibility;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;

        /*******************************************************************/
        public void Remove(string investigatorId)
        {
            UpdateModel(investigatorId);
            UpdateView(investigatorId);
        }

        private void UpdateModel(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            selector.Remove(investigator);
        }

        private void UpdateView(string investigatorId)
        {
            investigatorVisibility.RefreshInvestigatorsSelectability();
            investigatorSelector.RemoveInvestigator(investigatorId);
            investigatorSelector.SetLeadSelector();
            readyButton.AutoActivate();
        }
    }
}
