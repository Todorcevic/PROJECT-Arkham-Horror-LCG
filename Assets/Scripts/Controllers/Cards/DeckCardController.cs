using Arkham.EventData;
using Zenject;

namespace Arkham.Controllers
{
    public class DeckCardController : IController
    {
        [Inject] private readonly IAddCard addCard;

        /*******************************************************************/
        public void Click(IViewInteractable deckCardView)
        {
            deckCardView.InteractableEffects.ClickEffect();
            addCard.AddDeckCard(deckCardView.Id);
        }

        public void DoubleClick(IViewInteractable deckCardView) =>
            deckCardView.InteractableEffects.DoubleClickEffect();

        public void HoverOn(IViewInteractable deckCardView) =>
            deckCardView.InteractableEffects.HoverOnEffect();

        public void HoverOff(IViewInteractable deckCardView) =>
            deckCardView.InteractableEffects.HoverOffEffect();
    }
}
