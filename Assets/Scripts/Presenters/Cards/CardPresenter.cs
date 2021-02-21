using Arkham.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Presenters
{
    public class CardPresenter : ICardPresenter
    {
        [Inject] private readonly IInvestigatorCardsManager investigatorManager;

        /*******************************************************************/
        public void EnableCard(string investigatorId, bool isEnable) =>
            investigatorManager.AllInvestigatorCards[investigatorId].Enable(isEnable);
    }
}
