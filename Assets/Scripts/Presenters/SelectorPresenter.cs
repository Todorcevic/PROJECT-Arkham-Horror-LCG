using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Views;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkham.Presenters
{
    public class SelectorPresenter : ISelectorPresenter
    {
        private string investigatorSelected;
        [Inject] private readonly IInvestigatorSelectorsManager selectorManager;
        [Inject] private readonly IInvestigatorCardsManager investigatorManager;
        [Inject] private readonly ISelectorInteractor selectorInteractor;
        public List<ISelectorView> Selectors => selectorManager.Selectors;

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
            selectorManager.ArrangeSelectors();
        }

        public void RemoveInvestigator(string investigatorId)
        {
            selectorManager.GetSelectorByInvestigator(investigatorId).SetInvestigator(null);
            selectorManager.ArrangeSelectors();
        }

        private void InitializeSelectors()
        {
            foreach (string investigatorId in selectorInteractor.InvestigatorsSelectedList)
                SetInvestigator(investigatorId);
        }

        private ISelectorView SetInvestigator(string investigatorId)
        {
            ISelectorView selector = selectorManager.GetSelectorVoid();
            Sprite spriteCard = investigatorManager.GetSpriteCard(investigatorId);
            selector.SetInvestigator(investigatorId, spriteCard);
            return selector;
        }
    }
}
