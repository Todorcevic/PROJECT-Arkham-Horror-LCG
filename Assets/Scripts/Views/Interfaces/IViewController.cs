using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Views
{
    public interface IViewController
    {
        void ClickEffect();
        void HoverOnEffect();
        void HoverOffEffect();
    }
}
