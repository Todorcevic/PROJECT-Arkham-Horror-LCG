using Arkham.Interactors;
using Arkham.EventData;
using Zenject;

namespace Arkham.Controllers
{
    public class CardSelectorController : IController
    {
        [Inject] private readonly IRemoveCard removeCard;
        [Inject] private readonly IClickableCards clickableCards;
        /*******************************************************************/

        public void Click(IViewInteractable selectorView)
        {
            if (!clickableCards.IsClickable(selectorView.Id)) return;
            selectorView.InteractableEffects.ClickEffect();
            removeCard.RemoveDeckCard(selectorView.Id);
        }

        public void DoubleClick(IViewInteractable selectorView) => selectorView.InteractableEffects.DoubleClickEffect();

        public void HoverOn(IViewInteractable selectorView) => selectorView.InteractableEffects.HoverOnEffect();

        public void HoverOff(IViewInteractable selectorView) => selectorView.InteractableEffects.HoverOffEffect();
    }
}
