using Arkham.Interactors;
using Arkham.Views;
using Zenject;

namespace Arkham.Controllers
{
    public class InvestigatorCardController : CardController, IInvestigatorCardController
    {
        [Inject] private readonly IInvestigatorSelectorInteractor selectorInteractor;

        /*******************************************************************/
        protected override void Click(ICardView cardView) =>
            selectorInteractor.AddInvestigator(cardView.Id);
    }
}
