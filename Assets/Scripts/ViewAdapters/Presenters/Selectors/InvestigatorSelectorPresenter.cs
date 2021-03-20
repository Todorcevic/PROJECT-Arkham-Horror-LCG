using Arkham.Interactors;
using Arkham.Managers;
using Arkham.EventData;
using Arkham.Repositories;
using UnityEngine;
using Zenject;
using Arkham.Views;

namespace Arkham.Presenters
{
    public class InvestigatorSelectorPresenter : IInitializable
    {
        private string investigatorSelected;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly IInvestigatorCardsManager investigatorCardsManager;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
        [Inject] private readonly ISelectInvestigatorEvent selectInvestigatorEvent;
        [Inject] private readonly IAddInvestigatorEvent addInvestigatorEventData;
        [Inject] private readonly IRemoveInvestigatorEvent removeInvestigatorEvent;
        [Inject] private readonly IChangeInvestigatorEvent changeInvestigatorEvent;
        [Inject] private readonly IStartGameEvent startGameEvent;
        [Inject] private readonly ISelectInvestigator selectInvestigator;

        private string LeadInvestigator => investigatorSelectorInteractor.LeadInvestigator;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            selectInvestigatorEvent.InvestigatorSelectedChanged += SelectInvestigator;
            addInvestigatorEventData.InvestigatorAdded += AddInvestigator;
            removeInvestigatorEvent.InvestigatorRemoved += RemoveInvestigator;
            changeInvestigatorEvent.InvestigatorChanged += ChangeInvestigator;
            startGameEvent.GameStarted += InitializeSelectors;
        }

        /*******************************************************************/
        private void InitializeSelectors()
        {
            CleanAllSelectors();
            AddAllInvestigators();
            SelectLeadInvestigator();
        }

        private void CleanAllSelectors() => investigatorSelectorsManager.Selectors.ForEach(s => s.SetSelector(null));
        private void AddAllInvestigators() =>
            investigatorSelectorRepository.InvestigatorsSelectedList.ForEach(i => AddInvestigator(i));
        private void SelectLeadInvestigator() =>
            selectInvestigator.SelectInvestigator(investigatorSelectorInteractor.LeadInvestigator);

        /*******************************************************************/
        private void SelectInvestigator(string activeInvestigatorId)
        {
            RemoveGlowInOldInvestigator();
            ActiveGlowInNewInvestigator(activeInvestigatorId);
            investigatorSelected = activeInvestigatorId;
        }

        private void RemoveGlowInOldInvestigator() =>
            investigatorSelectorsManager.GetSelectorById(investigatorSelected)?.GlowActivator.ActivateGlow(false);
        private void ActiveGlowInNewInvestigator(string activeInvestigatorId) =>
            investigatorSelectorsManager.GetSelectorById(activeInvestigatorId)?.GlowActivator.ActivateGlow(true);

        /*******************************************************************/
        private void AddInvestigator(string investigatorId)
        {
            InvestigatorSelectorView selector = investigatorSelectorsManager.GetEmptySelector();
            Sprite spriteCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            selector.SetSelector(investigatorId, spriteCard);
            selector.SelectorMovement.MoveImageTo(investigatorCardsManager.AllCards[investigatorId].Transform.position);
            selector.SelectorMovement.SetTransform(investigatorSelectorsManager.PlaceHoldersZone);
            selector.SelectorMovement.Arrange();
            SetLeadSelector();
        }

        /*******************************************************************/
        private void RemoveInvestigator(string investigatorId)
        {
            InvestigatorSelectorView selector = investigatorSelectorsManager.GetSelectorById(investigatorId);
            selector.SelectorMovement.SetTransform();
            selector.SetSelector(null);
            ArrangeAllSelectors();
            SetLeadSelector();
        }

        private void ArrangeAllSelectors() =>
            investigatorSelectorsManager.Selectors.ForEach(s => s.SelectorMovement.Arrange());

        /*******************************************************************/
        private void ChangeInvestigator(string inv1, string inv2)
        {
            InvestigatorSelectorView selector1 = investigatorSelectorsManager.GetSelectorById(inv1);
            InvestigatorSelectorView selector2 = investigatorSelectorsManager.GetSelectorById(inv2);
            selector1.SelectorMovement.SwapPlaceHolder(selector2.SelectorMovement.PlaceHolder);
            selector1.SelectorMovement.Arrange();
            SetLeadSelector();
        }

        /*******************************************************************/
        private void SetLeadSelector()
        {
            if (LeadInvestigator == investigatorSelectorsManager.GetLeadSelector.Id || LeadInvestigator == null) return;
            investigatorSelectorsManager.GetLeadSelector.LeadActivator.ActivateLeaderIcon(false);
            investigatorSelectorsManager.GetSelectorById(LeadInvestigator).LeadActivator.ActivateLeaderIcon(true);
        }
    }
}