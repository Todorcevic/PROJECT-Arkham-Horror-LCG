using Arkham.Interactors;
using Arkham.Presenters;
using Zenject;

namespace Arkham.Controllers
{
    public class DeckCardController : CardController, IDeckCardController
    {
        [Inject] private readonly IDeckBuilderInteractor investigatorsInteractor;

        /*******************************************************************/
        protected override void Click(ICardVisualizable cardView) =>
            investigatorsInteractor.AddDeckCard(cardView.Id);
    }
}
