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
        public void Init(ICardView cardView)
        {
            cardView.Interactable.DoubleClicked += () => DoubleClick(cardView);
        }

        protected abstract void DoubleClick(ICardView cardView);
    }
}
