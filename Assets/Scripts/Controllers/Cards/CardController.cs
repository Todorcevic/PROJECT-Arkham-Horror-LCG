using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.EventSystems;

namespace Arkham.Controllers
{
    public class CardController : IHoverController<ICardView>
    {
        public void HoverOn(ICardView cardView, PointerEventData eventData = null)
        {
            cardView.HoverOnEffect();
        }

        public void HoverOff(ICardView cardView, PointerEventData eventData = null)
        {
            cardView.HoverOffEffect();
        }
    }
}
