using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Controllers
{
    public interface IInvestigatorSelectorController
    {
        void Init(IInvestigatorSelectorView selectorView);
        void Click();
        void DoubleClick();
        void HoverOn();
        void HoverOff();
    }
}
