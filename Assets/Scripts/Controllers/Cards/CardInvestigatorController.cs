using Arkham.Managers;
using Arkham.Repositories;
using Arkham.Views;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public class CardInvestigatorController : CardController, ICardController
    {
        [Inject] private readonly ISelectorRepository selectorRepository;
        [Inject] private readonly IInvestigatorSelectorsManager selectorsManager;
        private List<string> InvestigatorsSelected => selectorRepository.InvestigatorsSelectedList;

        /*******************************************************************/
        protected override int AmountSelected(string investigatorId) =>
            InvestigatorsSelected.FindAll(s => s == investigatorId).Count;

        public void DoubleClick()
        {
            selectorsManager.AddInvestigator(cardView);
            SwitchEnable();
        }
    }
}
