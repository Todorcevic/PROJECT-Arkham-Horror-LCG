using Arkham.Interactors;
using Arkham.Presenters;
using Arkham.EventData;
using Zenject;

namespace Arkham.Controllers
{
    public class DeckCardController : CardController, IDeckCardController
    {
        [Inject] private readonly IAddCard addCard;
        [Inject] private readonly Interactors.ICardSelectorInteractors investigatorsInteractor;

        /*******************************************************************/
        protected override void Click(IViewInteractable cardView)
        {
            cardView.Interactable.ClickEffect();
            addCard.AddDeckCard(cardView.Id);
        }
    }
}
