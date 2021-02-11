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
        void Click(InvestigatorSelectorView selectorView);
        void DoubleClick(InvestigatorSelectorView selectorView);
        void HoverOn(InvestigatorSelectorView selectorView);
        void HoverOff(InvestigatorSelectorView selectorView);
    }
}
