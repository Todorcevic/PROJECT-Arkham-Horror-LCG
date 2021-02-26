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
        public List<IInvestigatorSelectorView> Selectors => investigatorSelectorsManager.InvestigatorSelectors;

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
            investigatorSelectorsManager.GetSelectorByInvestigatorId(investigatorSelected)?.ActivateGlow(false);
            investigatorSelectorsManager.GetSelectorByInvestigatorId(activeInvestigatorId)?.ActivateGlow(true);
            investigatorSelected = activeInvestigatorId;
        }

        public void AddInvestigator(string investigatorId)
        {
            SetInvestigatorInVoidSelector(investigatorId).MoveTo(investigatorCardsManager.AllCards[investigatorId].Transform);
            ArrangeSelectors();
        }

        public void RemoveInvestigator(string investigatorId)
        {
            investigatorSelectorsManager.GetSelectorByInvestigatorId(investigatorId).SetSelector(null);
            ArrangeSelectors();
        }

        private void InitializeSelectors()
        {
            foreach (string investigatorId in investigatorSelectorInteractor.InvestigatorsSelectedList)
                SetInvestigatorInVoidSelector(investigatorId);
        }

        private ISelectorView SetInvestigatorInVoidSelector(string investigatorId)
        {
            ISelectorView selector = investigatorSelectorsManager.GetVoidSelector();
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
            if (investigatorSelectorsManager.GetLeadSelector().CardInThisSelector == LeadInvestigator) return;
            investigatorSelectorsManager.GetLeadSelector().ActivateLeaderIcon(false);
            investigatorSelectorsManager.GetSelectorByInvestigatorId(LeadInvestigator).ActivateLeaderIcon(true);
        }
    }
}
