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

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            selectInvestigatorEvent.InvestigatorSelectedChanged += SelectInvestigator;
            addInvestigatorEventData.InvestigatorAdded += AddInvestigator;
            removeInvestigatorEvent.InvestigatorRemoved += RemoveInvestigator;
            changeInvestigatorEvent.InvestigatorChanged += ChangeInvestigator;
            InitializeSelectors();
        }

        /*******************************************************************/
        private void InitializeSelectors() =>
            investigatorSelectorRepository.InvestigatorsSelectedList.ForEach(i => AddInvestigator(i));


        private void SelectInvestigator(string activeInvestigatorId)
        {
            investigatorSelectorsManager.GetSelectorById(investigatorSelected)?.ActivateGlow(false);
            investigatorSelectorsManager.GetSelectorById(activeInvestigatorId)?.ActivateGlow(true);
            investigatorSelected = activeInvestigatorId;
        }

        private void AddInvestigator(string investigatorId)
        {
            InvestigatorSelectorView selector = investigatorSelectorsManager.GetEmptySelector();
            Sprite spriteCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            selector.SetSelector(investigatorId, spriteCard);
            selector.SelectorMovement.MoveImageTo(investigatorCardsManager.AllCards[investigatorId].Transform);
            selector.SelectorMovement.SetTransform(investigatorSelectorsManager.PlaceHoldersZone);
            selector.SelectorMovement.Arrange();
            investigatorSelectorsManager.SetLeadSelector(investigatorSelectorInteractor.LeadInvestigator);
        }

        private void RemoveInvestigator(string investigatorId)
        {
            InvestigatorSelectorView selector = investigatorSelectorsManager.GetSelectorById(investigatorId);
            selector.SelectorMovement.SetTransform();
            selector.SetSelector(null);
            investigatorSelectorsManager.ArrangeSelectorsAndSetThisLead(investigatorSelectorInteractor.LeadInvestigator);
        }

        private void ChangeInvestigator(string inv1, string inv2)
        {
            InvestigatorSelectorView selector1 = investigatorSelectorsManager.GetSelectorById(inv1);
            InvestigatorSelectorView selector2 = investigatorSelectorsManager.GetSelectorById(inv2);
            selector1.SelectorMovement.SwapPlaceHolder(selector2.SelectorMovement.PlaceHolder);
            selector1.SelectorMovement.Arrange();
            investigatorSelectorsManager.SetLeadSelector(investigatorSelectorInteractor.LeadInvestigator);
        }
    }
}