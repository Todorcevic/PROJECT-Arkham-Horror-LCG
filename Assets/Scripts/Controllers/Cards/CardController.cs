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
            cardView.Interactable.Clicked += () => Click(cardView);
        }

        protected abstract void Click(ICardView cardView);
    }
}
