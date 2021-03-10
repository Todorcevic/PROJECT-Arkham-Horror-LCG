using Arkham.Interactors;
using Arkham.Managers;
using Arkham.EventData;
using UnityEngine;
using Zenject;
using Arkham.Repositories;

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

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            selectInvestigatorEvent.InvestigatorSelectedChanged += SelectInvestigator;
            addInvestigatorEventData.InvestigatorAdded += AddInvestigator;
            removeInvestigatorEvent.InvestigatorRemoved += RemoveInvestigator;
            InitializeSelectors();
        }

        /*******************************************************************/
        private void InitializeSelectors()
        {
            foreach (string investigatorId in investigatorSelectorRepository.InvestigatorsSelectedList)
            {
                IInvestigatorSelector selector = investigatorSelectorsManager.GetEmptySelector();
                SetInvestigatorInSelector(investigatorId, selector);
            }
            investigatorSelectorsManager.ArrangeSelectors();
        }

        private void SelectInvestigator(string activeInvestigatorId)
        {
            investigatorSelectorsManager.GetSelectorById(investigatorSelected)?.ActivateGlow(false);
            investigatorSelectorsManager.GetSelectorById(activeInvestigatorId)?.ActivateGlow(true);
            investigatorSelected = activeInvestigatorId;
        }

        private void AddInvestigator(string investigatorId)
        {
            IInvestigatorSelector selector = investigatorSelectorsManager.GetEmptySelector();
            SetInvestigatorInSelector(investigatorId, selector);
            selector.SelectorMovement.MoveImageTo(investigatorCardsManager.AllCards[investigatorId].Transform);
            investigatorSelectorsManager.ArrangeSelectors();
        }

        private void RemoveInvestigator(string investigatorId)
        {
            investigatorSelectorsManager.GetSelectorById(investigatorId).SetSelector(null);
            investigatorSelectorsManager.ArrangeSelectors();
        }

        private void SetInvestigatorInSelector(string investigatorId, IInvestigatorSelector selector)
        {
            Sprite spriteCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            selector.SetSelector(investigatorId, spriteCard);
        }
    }
}