using Arkham.Interactors;
using Arkham.Managers;
using Arkham.EventData;
using Arkham.Repositories;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorSelectorPresenter : IInitializable
    {
        private string investigatorSelected;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly IInvestigatorCardsManager investigatorCardsManager;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
        [Inject] private readonly ISelectInvestigator selectInvestigator;
        [Inject] private readonly IStartGameEvent startGameEvent;
        [Inject] private readonly ISelectInvestigatorEvent selectInvestigatorEvent;
        [Inject] private readonly IAddInvestigatorEvent addInvestigatorEvent;
        [Inject] private readonly IRemoveInvestigatorEvent removeInvestigatorEvent;
        [Inject] private readonly IChangeInvestigatorEvent changeInvestigatorEvent;

        private string LeadInvestigator => investigatorSelectorInteractor.LeadInvestigator;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            startGameEvent.AddAction(InitializeSelectors);
            selectInvestigatorEvent.AddAction(SelectInvestigator);
            addInvestigatorEvent.AddAction(AddInvestigator);
            removeInvestigatorEvent.AddAction(RemoveInvestigator);
            changeInvestigatorEvent.AddAction(ChangeInvestigator);
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
            selectInvestigator.Selecting(investigatorSelectorInteractor.LeadInvestigator);

        /*******************************************************************/
        private void SelectInvestigator(string activeInvestigatorId)
        {
            RemoveGlowInOldInvestigator();
            ActiveGlowInNewInvestigator(activeInvestigatorId);
            investigatorSelected = activeInvestigatorId;
        }

        private void RemoveGlowInOldInvestigator() =>
            investigatorSelectorsManager.GetSelectorById(investigatorSelected)?.Glow(false);

        private void ActiveGlowInNewInvestigator(string activeInvestigatorId) =>
            investigatorSelectorsManager.GetSelectorById(activeInvestigatorId)?.Glow(true);

        /*******************************************************************/
        private void AddInvestigator(string investigatorId)
        {
            InvestigatorSelectorView selector = investigatorSelectorsManager.GetEmptySelector();
            Sprite spriteCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            selector.SetTransform(investigatorSelectorsManager.PlaceHoldersZone);
            investigatorSelectorsManager.RebuildPlaceHolders();
            selector.SetSelector(investigatorId, spriteCard);
            selector.SetImageAnimation();
            SetLeadSelector();
        }

        /*******************************************************************/
        private void RemoveInvestigator(string investigatorId)
        {
            InvestigatorSelectorView selector = investigatorSelectorsManager.GetSelectorById(investigatorId);
            selector.SetTransform();
            investigatorSelectorsManager.RebuildPlaceHolders();
            selector.SetSelector(null);
            ArrangeAllSelectors();
            SetLeadSelector();
        }

        private void ArrangeAllSelectors() => investigatorSelectorsManager.Selectors.ForEach(s => s.ArrangeAnimation());

        /*******************************************************************/
        private void ChangeInvestigator(string investigatorId1, string investigatorId2)
        {
            InvestigatorSelectorView selector1 = investigatorSelectorsManager.GetSelectorById(investigatorId1);
            InvestigatorSelectorView selector2 = investigatorSelectorsManager.GetSelectorById(investigatorId2);
            selector1.SwapPlaceHolderWith(selector2);
            investigatorSelectorsManager.RebuildPlaceHolders();
            selector1.ArrangeAnimation();
            SetLeadSelector();
        }

        /*******************************************************************/
        private void SetLeadSelector()
        {
            if (LeadInvestigator == investigatorSelectorsManager.GetLeadSelector.Id || LeadInvestigator == null) return;
            investigatorSelectorsManager.GetLeadSelector.LeadIcon(false);
            investigatorSelectorsManager.GetSelectorById(LeadInvestigator).LeadIcon(true);
        }
    }
}