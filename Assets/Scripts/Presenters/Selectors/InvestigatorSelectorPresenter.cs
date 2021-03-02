using Arkham.Interactors;
using Arkham.Managers;
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

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            investigatorSelectorInteractor.InvestigatorSelectedChanged += SelectInvestigator;
            investigatorSelectorInteractor.InvestigatorAdded += AddInvestigator;
            investigatorSelectorInteractor.InvestigatorRemoved += RemoveInvestigator;
            InitializeSelectors();
            investigatorSelectorInteractor.SelectLeadInvestigator();
        }

        /*******************************************************************/
        private void InitializeSelectors()
        {
            foreach (string investigatorId in investigatorSelectorInteractor.InvestigatorsSelectedList)
            {
                IInvestigatorSelectorable selector = investigatorSelectorsManager.GetEmptySelector();
                SetInvestigatorInSelector(investigatorId, selector);
            }
        }

        private void SelectInvestigator(string activeInvestigatorId)
        {
            investigatorSelectorsManager.GetSelectorById(investigatorSelected)?.ActivateGlow(false);
            investigatorSelectorsManager.GetSelectorById(activeInvestigatorId)?.ActivateGlow(true);
            investigatorSelected = activeInvestigatorId;
        }

        private void AddInvestigator(string investigatorId)
        {
            IInvestigatorSelectorable selector = investigatorSelectorsManager.GetEmptySelector();
            SetInvestigatorInSelector(investigatorId, selector);
            selector.MoveTo(investigatorCardsManager.AllCards[investigatorId].Transform);
            investigatorSelectorsManager.SetLeadAndArrangeSelectors(investigatorSelectorInteractor.LeadInvestigator);
        }

        private void RemoveInvestigator(string investigatorId)
        {
            investigatorSelectorsManager.GetSelectorById(investigatorId).SetSelector(null);
            investigatorSelectorsManager.SetLeadAndArrangeSelectors(investigatorSelectorInteractor.LeadInvestigator);
        }

        private void SetInvestigatorInSelector(string investigatorId, IInvestigatorSelectorable selector)
        {
            Sprite spriteCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            selector.SetSelector(investigatorId, spriteCard);
        }
    }
}