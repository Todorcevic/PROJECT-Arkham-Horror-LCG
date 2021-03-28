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
        [Inject] private readonly ISelectInvestigator selectInvestigator;
        [Inject] private readonly ISelectInvestigatorEvent selectInvestigatorEvent;
        [Inject] private readonly IAddInvestigatorEvent addInvestigatorEventData;
        [Inject] private readonly IRemoveInvestigatorEvent removeInvestigatorEvent;
        [Inject] private readonly IChangeInvestigatorEvent changeInvestigatorEvent;
        [Inject] private readonly IStartGameEvent startGameEvent;

        [Inject] private readonly IShowCard showCard;

        private string LeadInvestigator => investigatorSelectorInteractor.LeadInvestigator;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            selectInvestigatorEvent.AddAction(SelectInvestigator);
            addInvestigatorEventData.AddAction(AddInvestigator);
            removeInvestigatorEvent.AddAction(RemoveInvestigator);
            changeInvestigatorEvent.AddAction(ChangeInvestigator);
            startGameEvent.AddAction(InitializeSelectors);
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
            IInvestigatorSelectorView selector = investigatorSelectorsManager.GetEmptySelector();
            Sprite spriteCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            selector.SetSelector(investigatorId, spriteCard);
            selector.MoveImageTo(investigatorCardsManager.AllCards[investigatorId].Transform.position);
            selector.SetTransform(investigatorSelectorsManager.PlaceHoldersZone);
            selector.Arrange();
            SetLeadSelector();
        }

        /*******************************************************************/
        private void RemoveInvestigator(string investigatorId)
        {
            IInvestigatorSelectorView selector = investigatorSelectorsManager.GetSelectorById(investigatorId);
            selector.SetTransform();
            selector.SetSelector(null);
            ArrangeAllSelectors();
            SetLeadSelector();
        }

        private void ArrangeAllSelectors() =>
            investigatorSelectorsManager.Selectors.ForEach(s => s.Arrange());

        /*******************************************************************/
        private void ChangeInvestigator(string inv1, string inv2)
        {
            IInvestigatorSelectorView selector1 = investigatorSelectorsManager.GetSelectorById(inv1);
            IInvestigatorSelectorView selector2 = investigatorSelectorsManager.GetSelectorById(inv2);
            selector1.SwapPlaceHolder(selector2.PlaceHolder);
            selector1.Arrange();
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