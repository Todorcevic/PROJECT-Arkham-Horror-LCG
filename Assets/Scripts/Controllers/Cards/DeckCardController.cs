using Arkham.EventData;
using Zenject;

namespace Arkham.Controllers
{
    public class DeckCardController : CardController, IDeckCardController
    {
        [Inject] private readonly IAddCard addCard;

        /*******************************************************************/
        protected override void Click(IViewInteractable cardView)
        {
            cardView.Interactable.ClickEffect();
            addCard.AddDeckCard(cardView.Id);
        }
    }
}
