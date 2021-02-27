using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Views;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkham.Presenters
{
    public class InvestigatorSelectorPresenter : IInvestigatorSelectorPresenter
    {
        private string investigatorSelected;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly IInvestigatorCardsManager investigatorCardsManager;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        private string LeadInvestigator => investigatorSelectorInteractor.LeadInvestigator;
        public List<IInvestigatorSelectorView> Selectors => investigatorSelectorsManager.Selectors;

        /*******************************************************************/
        public void Init()
        {
            investigatorSelectorInteractor.InvestigatorSelectedChanged += SelectInvestigator;
            investigatorSelectorInteractor.InvestigatorAdded += AddInvestigator;
            investigatorSelectorInteractor.InvestigatorRemoved += RemoveInvestigator;
            InitializeSelectors();
            investigatorSelectorInteractor.SelectInvestigator(LeadInvestigator);
        }

        public void SelectInvestigator(string activeInvestigatorId)
        {
            investigatorSelectorsManager.GetSelectorById(investigatorSelected)?.ActivateGlow(false);
            investigatorSelectorsManager.GetSelectorById(activeInvestigatorId)?.ActivateGlow(true);
            investigatorSelected = activeInvestigatorId;
        }

        public void AddInvestigator(string investigatorId)
        {
            SetInvestigatorInVoidSelector(investigatorId).MoveTo(investigatorCardsManager.AllCards[investigatorId].Transform);
            ArrangeSelectors();
        }

        public void RemoveInvestigator(string investigatorId)
        {
            investigatorSelectorsManager.GetSelectorById(investigatorId).SetSelector(null);
            ArrangeSelectors();
        }

        private void InitializeSelectors()
        {
            foreach (string investigatorId in investigatorSelectorInteractor.InvestigatorsSelectedList)
                SetInvestigatorInVoidSelector(investigatorId);
        }

        private IInvestigatorSelectorView SetInvestigatorInVoidSelector(string investigatorId)
        {
            IInvestigatorSelectorView selector = investigatorSelectorsManager.GetEmptySelector();
            Sprite spriteCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            selector.SetSelector(investigatorId, spriteCard);
            return selector;
        }

        private void ArrangeSelectors()
        {
            SetLeadSelector();
            foreach (IInvestigatorSelectorView selector in Selectors)
                selector.Arrange(selector.IsEmpty ? selector.Transform : investigatorSelectorsManager.PlaceHolder);
        }

        private void SetLeadSelector()
        {
            if (GetLeadSelector().CardInThisSelector == LeadInvestigator) return;
            GetLeadSelector().ActivateLeaderIcon(false);
            investigatorSelectorsManager.GetSelectorById(LeadInvestigator).ActivateLeaderIcon(true);
        }

        private IInvestigatorSelectorView GetLeadSelector() => Selectors.Find(i => i.IsLead);
    }
}
