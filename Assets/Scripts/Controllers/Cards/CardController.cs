using Arkham.Presenters;

namespace Arkham.Controllers
{
    public abstract class CardController
    {
        public void Init(IViewInteractable cardView)
        {
            cardView.Interactable.Clicked += () => Click(cardView);
            cardView.Interactable.DoubleClicked += () => Click(cardView);
            cardView.Interactable.HoverOn += cardView.Interactable.HoverOnEffect;
            cardView.Interactable.HoverOff += cardView.Interactable.HoverOffEffect;
        }

        protected abstract void Click(IViewInteractable cardView);
    }
}
