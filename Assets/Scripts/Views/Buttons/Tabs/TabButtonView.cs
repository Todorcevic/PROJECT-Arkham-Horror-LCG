using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Views
{
    public class TabButtonView : ButtonView
    {
        public void HoverActive() => effects.HoverActivate();

        public void HoverDesactive() => effects.HoverDesactivate();
    }
}
