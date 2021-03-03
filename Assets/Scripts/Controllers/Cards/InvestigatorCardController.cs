using Arkham.Interactors;
using Arkham.Presenters;
using Zenject;

namespace Arkham.Controllers
{
    public class InvestigatorCardController : CardController, IInvestigatorCardController
    {
        [Inject] private readonly IInvestigatorSelectorInteractor selectorInteractor;

        /*******************************************************************/
        protected override void Click(IViewInteractable cardView)
        {
            cardView.Interactable.ClickEffect();
            selectorInteractor.AddInvestigator(cardView.Id);
        }
    }
}
