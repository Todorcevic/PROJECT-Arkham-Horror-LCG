using Arkham.Interactors;
using Arkham.Views;
using Zenject;

namespace Arkham.Controllers
{
    public class InvestigatorCardController : CardController, IInvestigatorCardController
    {
        [Inject] private readonly ISelectorInteractor selectorInteractor;

        protected override void DoubleClick(ICardView cardView)
        {
            cardView.DoubleClick();
            selectorInteractor.AddInvestigator(cardView.Id);
        }
    }
}
