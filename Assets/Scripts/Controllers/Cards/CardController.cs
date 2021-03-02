using Arkham.Presenters;

namespace Arkham.Controllers
{
    public abstract class CardController
    {
        public void Init(ICardVisualizable cardView)
        {
            cardView.Interactable.Clicked += () => Click(cardView);
            cardView.Interactable.DoubleClicked += () => Click(cardView);
        }

        protected abstract void Click(ICardVisualizable cardView);
    }
}
