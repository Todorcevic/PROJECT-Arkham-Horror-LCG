using Arkham.Managers;
using Arkham.Presenters;
using Arkham.Repositories;
using Arkham.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Arkham.Interactors
{
    public class InvestigatorsSelectorInteractor : IInvestigatorsSelectorInteractor
    {
        [Inject] private readonly ISelectorPresenter selectorPresenter;
        [Inject] private readonly IInvestigatorsSelectedRepository investigatorsSelectedModel;
        [Inject] private readonly IInvestigatorCardInteractor investigatorCardInteractor;
        [Inject] private readonly IInvestigatorCardActivator investigatorCardActivator;

        /*******************************************************************/
        public void InitializeSelectors()
        {
            foreach (string investigatorId in investigatorsSelectedModel.InvestigatorsSelectedList)
            {
                investigatorCardInteractor.ActivateCard(investigatorId);
                selectorPresenter.SetInvestigator(investigatorId);
            }
        }

        public void SelectInvestigator(string investigatorId)
        {
            selectorPresenter.FocusInvestigator(investigatorId, investigatorsSelectedModel.InvestigatorFocused);
            investigatorsSelectedModel.InvestigatorFocused = investigatorId;
        }

        public void AddInvestigator(string investigatorId)
        {
            investigatorsSelectedModel.InvestigatorsSelectedList.Add(investigatorId);
            investigatorCardActivator.RefreshAllCards();
            selectorPresenter.AddInvestigator(investigatorId);
            SelectInvestigator(investigatorId);
        }

        public void RemoveInvestigator(string investigatorId)
        {
            investigatorsSelectedModel.InvestigatorsSelectedList.Remove(investigatorId);
            investigatorCardActivator.RefreshAllCards();
            selectorPresenter.RemoveInvestigator(investigatorId);
            SelectInvestigator(investigatorsSelectedModel.InvestigatorsSelectedList.FirstOrDefault());
        }
    }
}
