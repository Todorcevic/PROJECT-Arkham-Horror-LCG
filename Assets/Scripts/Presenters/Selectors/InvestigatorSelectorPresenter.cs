using Arkham.Interactors;
using Arkham.Managers;
using Arkham.EventData;
using Arkham.Repositories;
using UnityEngine;
using Zenject;

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
            IInvestigatorSelector selector = investigatorSelectorsManager.GetEmptySelector();
            Sprite spriteCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            selector.SetSelector(investigatorId, spriteCard);
            selector.MoveImageTo(investigatorCardsManager.AllCards[investigatorId].Transform);
            selector.SetTransform(investigatorSelectorsManager.PlaceHolderZone);
            selector.ArrangeTo();
            investigatorSelectorsManager.SetLeadSelector(investigatorSelectorInteractor.LeadInvestigator);
        }

        private void RemoveInvestigator(string investigatorId)
        {
            IInvestigatorSelector selector = investigatorSelectorsManager.GetSelectorById(investigatorId);
            selector.SetSelector(null);
            investigatorSelectorsManager.ArrangeSelectorsAndSetThisLead(investigatorSelectorInteractor.LeadInvestigator);
        }

        private void ChangeInvestigator(string inv1, string inv2)
        {
            IInvestigatorSelector selector1 = investigatorSelectorsManager.GetSelectorById(inv1);
            IInvestigatorSelector selector2 = investigatorSelectorsManager.GetSelectorById(inv2);
            selector1.SwapPlaceHolder(selector2.PlaceHolder);
            selector1.ArrangeTo();
            investigatorSelectorsManager.SetLeadSelector(investigatorSelectorInteractor.LeadInvestigator);
        }
    }
}