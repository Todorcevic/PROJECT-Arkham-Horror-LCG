using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Controllers
{
    public abstract class CardController
    {
        protected ICardView cardView;

        protected void Init()
        {
            cardView.Interactable.AddDoubleClickAction(() => DoubleClick());
            cardView.Interactable.AddHoverOnAction(() => cardView.HoverOnEffect());
            cardView.Interactable.AddHoverOffAction(() => cardView.HoverOffEffect());
        }

        protected abstract void DoubleClick();
    }
}
