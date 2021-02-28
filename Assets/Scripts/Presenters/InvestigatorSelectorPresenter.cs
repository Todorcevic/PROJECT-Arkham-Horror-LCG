using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Views;
using System.Collections;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Arkham.Presenters
{
    public class InvestigatorSelectorPresenter : IInitializablePresenter
    {
        private string investigatorSelected;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly IInvestigatorCardsManager investigatorCardsManager;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        private string LeadInvestigator => investigatorSelectorInteractor.LeadInvestigator;
        IEnumerable IInitializablePresenter.interactableViews =>
            investigatorSelectorsManager.Selectors.OfType<IInteractableView>();

        /*******************************************************************/
        void IInitializablePresenter.Init()
        {
            investigatorSelectorInteractor.InvestigatorSelectedChanged += SelectInvestigator;
            investigatorSelectorInteractor.InvestigatorAdded += AddInvestigator;
            investigatorSelectorInteractor.InvestigatorRemoved += RemoveInvestigator;
            InitializeSelectors();
            investigatorSelectorInteractor.SelectInvestigator(LeadInvestigator);
        }

        private void InitializeSelectors()
        {
            foreach (string investigatorId in investigatorSelectorInteractor.InvestigatorsSelectedList)
            {
                IInvestigatorSelectorView selector = investigatorSelectorsManager.GetEmptySelector();
                SetInvestigatorInSelector(investigatorId, selector);
            }
        }

        private void SelectInvestigator(string activeInvestigatorId)
        {
            investigatorSelectorsManager.GetSelectorById(investigatorSelected)?.ActivateGlow(false);
            investigatorSelectorsManager.GetSelectorById(activeInvestigatorId)?.ActivateGlow(true);
            investigatorSelected = activeInvestigatorId;
        }

        private void AddInvestigator(string investigatorId)
        {
            IInvestigatorSelectorView selector = investigatorSelectorsManager.GetEmptySelector();
            SetInvestigatorInSelector(investigatorId, selector);
            selector.MoveTo(investigatorCardsManager.AllCards[investigatorId].Transform);
            SetLeadAndArrangeSelectors();
        }

        private void RemoveInvestigator(string investigatorId)
        {
            investigatorSelectorsManager.GetSelectorById(investigatorId).SetSelector(null);
            SetLeadAndArrangeSelectors();
        }

        private void SetInvestigatorInSelector(string investigatorId, IInvestigatorSelectorView selector)
        {
            Sprite spriteCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            selector.SetSelector(investigatorId, spriteCard);
        }

        private void SetLeadAndArrangeSelectors()
        {
            SetLeadSelector();
            investigatorSelectorsManager.ArrangeSelectors();
        }

        private void SetLeadSelector()
        {
            if (investigatorSelectorsManager.GetLeadSelector.Id == LeadInvestigator) return;
            investigatorSelectorsManager.GetLeadSelector.ActivateLeaderIcon(false);
            investigatorSelectorsManager.GetSelectorById(LeadInvestigator).ActivateLeaderIcon(true);
        }
    }
}
