using Arkham.Views;

namespace Arkham.Controllers
{
    public abstract class CardController
    {
        public void Init(ICardView cardView)
        {
            cardView.Interactable.Clicked += () => Click(cardView);
            cardView.Interactable.DoubleClicked += () => Click(cardView);
        }

        protected abstract void Click(ICardView cardView);
    }
}
