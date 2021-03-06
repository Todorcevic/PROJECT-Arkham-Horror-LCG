using Arkham.Interactors;
using Arkham.Managers;
using Arkham.EventData;
using Zenject;

namespace Arkham.Controllers
{
    public class CardSelectorController : IInitializable
    {
        [Inject] private readonly IRemoveCard removeCard;
        [Inject] private readonly ICardSelectorsManager cardSelectorsManager;
        [Inject] private readonly IClickableCards clickableCards;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            foreach (IViewInteractable interactableView in cardSelectorsManager.Selectors)
                Suscribe(interactableView);
        }

        /*******************************************************************/
        private void Suscribe(IViewInteractable selectorView)
        {
            selectorView.Interactable.Clicked += () => Click(selectorView);
            selectorView.Interactable.DoubleClicked += selectorView.Interactable.DoubleClickEffect;
            selectorView.Interactable.HoverOn += selectorView.Interactable.HoverOnEffect;
            selectorView.Interactable.HoverOff += selectorView.Interactable.HoverOffEffect;
        }

        private void Click(IViewInteractable selectorView)
        {
            if (!clickableCards.IsClickable(selectorView.Id)) return;
            selectorView.Interactable.ClickEffect();
            removeCard.RemoveDeckCard(selectorView.Id);
        }
    }
}
