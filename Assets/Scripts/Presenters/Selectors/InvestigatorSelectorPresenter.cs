﻿using Arkham.Interactors;
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
                Debug.Log(selector.Id);
                SetInvestigatorInSelector(investigatorId, selector);
            }
            investigatorSelectorsManager.ArrangeSelectorsAndSetThisLead(investigatorSelectorInteractor.LeadInvestigator);
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
            selector.MoveImageTo(investigatorCardsManager.AllCards[investigatorId].Transform);
            investigatorSelectorsManager.ArrangeSelectorsAndSetThisLead(investigatorSelectorInteractor.LeadInvestigator);
        }

        private void RemoveInvestigator(string investigatorId)
        {
            investigatorSelectorsManager.GetSelectorById(investigatorId).SetSelector(null);
            investigatorSelectorsManager.ArrangeSelectorsAndSetThisLead(investigatorSelectorInteractor.LeadInvestigator);
        }

        private void SetInvestigatorInSelector(string investigatorId, IInvestigatorSelector selector)
        {
            Sprite spriteCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            selector.SetSelector(investigatorId, spriteCard);
        }
    }
}