using Arkham.Interactors;
using Arkham.Presenters;
using Zenject;

namespace Arkham.Controllers
{
    public class DeckCardController : CardController, IDeckCardController
    {
        [Inject] private readonly IDeckBuilderInteractor investigatorsInteractor;

        /*******************************************************************/
        protected override void Click(IViewInteractable cardView)
        {
            cardView.Interactable.ClickEffect();
            investigatorsInteractor.AddDeckCard(cardView.Id);
        }
    }
}
