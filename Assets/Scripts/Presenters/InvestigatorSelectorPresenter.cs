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
        [Inject] private readonly IInvestigatorSelectorsManager selectorManager;
        [Inject] private readonly IInvestigatorCardsManager investigatorManager;
        [Inject] private readonly IInvestigatorSelectorInteractor selectorInteractor;
        public List<IInvestigatorSelectorView> Selectors => selectorManager.Selectors;

        /*******************************************************************/
        public void Init()
        {
            selectorInteractor.InvestigatorSelectedChanged += SelectInvestigator;
            selectorInteractor.InvestigatorAdded += AddInvestigator;
            selectorInteractor.InvestigatorRemoved += RemoveInvestigator;
            InitializeSelectors();
        }

        public void SelectInvestigator(string activeInvestigatorId)
        {
            selectorManager.GetSelectorByInvestigator(investigatorSelected)?.ActivateGlow(false);
            selectorManager.GetSelectorByInvestigator(activeInvestigatorId)?.ActivateGlow(true);
            investigatorSelected = activeInvestigatorId;
        }

        public void AddInvestigator(string investigatorId)
        {
            SetInvestigator(investigatorId).MoveTo(investigatorManager.AllCards[investigatorId].Transform);
            ArrangeSelectors();
        }

        public void RemoveInvestigator(string investigatorId)
        {
            selectorManager.GetSelectorByInvestigator(investigatorId).SetInvestigator(null);
            ArrangeSelectors();
        }

        private void InitializeSelectors()
        {
            foreach (string investigatorId in selectorInteractor.InvestigatorsSelectedList)
                SetInvestigator(investigatorId);
        }

        private IInvestigatorSelectorView SetInvestigator(string investigatorId)
        {
            IInvestigatorSelectorView selector = selectorManager.GetVoidSelector();
            Sprite spriteCard = investigatorManager.GetSpriteCard(investigatorId);
            selector.SetInvestigator(investigatorId, spriteCard);
            return selector;
        }

        public void ArrangeSelectors()
        {
            SetLeadSelector();
            foreach (IInvestigatorSelectorView selector in Selectors)
                selector.Arrange(selector.IsEmpty ? selector.Transform : selectorManager.PlaceHolder);
        }

        private void SetLeadSelector()
        {
            if (selectorManager.GetLeadSelector().InvestigatorInThisSelector == selectorInteractor.LeadInvestigator) return;
            selectorManager.GetLeadSelector().ActivateLeader(false);
            selectorManager.GetSelectorByInvestigator(selectorInteractor.LeadInvestigator).ActivateLeader(true);
        }
    }
}
