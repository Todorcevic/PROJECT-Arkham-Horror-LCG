using Arkham.Interactors;
using Arkham.Presenters;
using Arkham.EventData;
using Zenject;

namespace Arkham.Controllers
{
    public class InvestigatorCardController : CardController, IInvestigatorCardController
    {
        [Inject] private readonly IAddInvestigator addInvestigator;
        [Inject] private readonly ISelectInvestigator selectInvestigator;

        /*******************************************************************/
        protected override void Click(IViewInteractable investigatorCardview)
        {
            investigatorCardview.Interactable.ClickEffect();
            addInvestigator.AddInvestigator(investigatorCardview.Id);
            selectInvestigator.SelectInvestigator(investigatorCardview.Id);
        }
    }
}
