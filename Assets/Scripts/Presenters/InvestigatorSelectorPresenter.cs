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
        [Inject(Id = "InvestigatorsSelector")] private readonly ISelectorsManager selectorsManager;
        [Inject(Id = "InvestigatorsManager")] private readonly ICardsManager cardsManager;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        private string LeadInvestigator => investigatorSelectorInteractor.LeadInvestigator;
        public List<IInvestigatorSelectorView> Selectors => selectorsManager.Selectors<IInvestigatorSelectorView>();

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
            selectorsManager.GetSelectorById<IInvestigatorSelectorView>(investigatorSelected)?.ActivateGlow(false);
            selectorsManager.GetSelectorById<IInvestigatorSelectorView>(activeInvestigatorId)?.ActivateGlow(true);
            investigatorSelected = activeInvestigatorId;
        }

        public void AddInvestigator(string investigatorId)
        {
            SetInvestigatorInVoidSelector(investigatorId).MoveTo(cardsManager.AllCards[investigatorId].Transform);
            ArrangeSelectors();
        }

        public void RemoveInvestigator(string investigatorId)
        {
            selectorsManager.GetSelectorById<IInvestigatorSelectorView>(investigatorId).SetSelector(null);
            ArrangeSelectors();
        }

        private void InitializeSelectors()
        {
            foreach (string investigatorId in investigatorSelectorInteractor.InvestigatorsSelectedList)
                SetInvestigatorInVoidSelector(investigatorId);
        }

        private IInvestigatorSelectorView SetInvestigatorInVoidSelector(string investigatorId)
        {
            IInvestigatorSelectorView selector = selectorsManager.GetEmptySelector<IInvestigatorSelectorView>();
            Sprite spriteCard = cardsManager.GetSpriteCard(investigatorId);
            selector.SetSelector(investigatorId, spriteCard);
            return selector;
        }

        private void ArrangeSelectors()
        {
            SetLeadSelector();
            foreach (IInvestigatorSelectorView selector in Selectors)
                selector.Arrange(selector.IsEmpty ? selector.Transform : selectorsManager.PlaceHolder);
        }

        private void SetLeadSelector()
        {
            if (GetLeadSelector().CardInThisSelector == LeadInvestigator) return;
            GetLeadSelector().ActivateLeaderIcon(false);
            selectorsManager.GetSelectorById<IInvestigatorSelectorView>(LeadInvestigator).ActivateLeaderIcon(true);
        }

        private IInvestigatorSelectorView GetLeadSelector() => Selectors.Find(i => i.IsLead);
    }
}
