using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Controllers
{
    public interface ICardController
    {
        void HoverOn(ICardView cardView);
        void HoverOff(ICardView cardView);
        void UpdateVisualState(ICardView cardView);
        void DoubleClick(ICardView cardView);
    }
}
