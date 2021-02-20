using Arkham.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Interactors
{
    public class InvestigatorCardInteractor : CardInteractor, IInvestigatorCardInteractor
    {
        [Inject] private readonly IInvestigatorsSelectedRepository investigatorsSelectedModel;

        /*******************************************************************/
        protected override int AmountCardsSelected(string cardId) =>
           investigatorsSelectedModel.InvestigatorsSelectedList.FindAll(i => i == cardId).Count;
    }
}
