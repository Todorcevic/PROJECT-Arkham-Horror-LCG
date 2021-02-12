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
        void Init(CardView cardView);
        void HoverOn();
        void HoverOff();
        void SwitchEnable();
        void DoubleClick();
    }
}
