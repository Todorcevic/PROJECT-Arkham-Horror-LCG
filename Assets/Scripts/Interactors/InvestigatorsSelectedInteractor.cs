using Arkham.Presenters;
using Arkham.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Arkham.Iterators
{
    public class InvestigatorsSelectedInteractor : IInvestigatorsSelectedInteractor
    {
        [Inject] private readonly ISelectorPresenter selectorPresenter;
        [Inject] private readonly IInvestigatorsSelectedRepository investigatorsSelectedModel;

        /*******************************************************************/
        public void InitializeSelectors()
        {
            foreach (string investigatorId in investigatorsSelectedModel.InvestigatorsSelectedList)
                selectorPresenter.SetInvestigator(investigatorId);
        }

        public void AddInvestigator(string investigatorId)
        {
            investigatorsSelectedModel.InvestigatorsSelectedList.Add(investigatorId);
            selectorPresenter.AddInvestigator(investigatorId);
        }

        public void RemoveInvestigator(string investigatorId)
        {
            investigatorsSelectedModel.InvestigatorsSelectedList.Remove(investigatorId);
            selectorPresenter.RemoveInvestigator(investigatorId);
        }

        public int AmountInvestigators(string investigatorId) =>
           investigatorsSelectedModel.InvestigatorsSelectedList.FindAll(i => i == investigatorId).Count;
    }
}
