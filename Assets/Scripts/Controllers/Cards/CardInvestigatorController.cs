using Arkham.Repositories;
using Arkham.UseCases;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.EventSystems;

namespace Arkham.Controllers
{
    public class CardInvestigatorController : IDoubleClickController<ICardInvestigatorView>
    {
        private readonly Repository allData;
        private readonly IInvestigatorSelector selectorLogic;

        /*******************************************************************/
        public CardInvestigatorController(Repository allData, IInvestigatorSelector selectorLogic)
        {
            this.allData = allData;
            this.selectorLogic = selectorLogic;
        }

        /*******************************************************************/

        public void DoubleClick(ICardInvestigatorView cardInvestigatorView, PointerEventData eventData = null)
        {
            selectorLogic.AddInvestigator(cardInvestigatorView.Id);
        }
    }
}
