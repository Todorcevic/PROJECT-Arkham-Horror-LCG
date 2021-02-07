using Arkham.Managers;
using Arkham.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Arkham.Presenters
{
    public class InvestigatorSelectorManagerPresenter : IPresenter<IInvestigatorSelectorManager>
    {
        private readonly Repository allData;
        private readonly CardRepository cardRepository;

        /*******************************************************************/
        public InvestigatorSelectorManagerPresenter(Repository allData, CardRepository cardRepository)
        {
            this.allData = allData;
            this.cardRepository = cardRepository;
        }

        public void CreateReactiveViewModel(IInvestigatorSelectorManager selectorManager)
        {
            allData.ObserveEveryValueChanged(allData => allData.InvestigatorSelected)
                .Select(investigatorId => allData.InvestigatorSelectorPosition(investigatorId))
                .Subscribe(index => selectorManager.ActivateSelector(index));
        }
    }
}
