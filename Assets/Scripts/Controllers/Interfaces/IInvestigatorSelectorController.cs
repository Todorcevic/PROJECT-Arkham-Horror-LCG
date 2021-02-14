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
        void InitializeSelector(IInvestigatorSelectorView selectorView);
        void Click(IInvestigatorSelectorView selectorView);
        void DoubleClick(IInvestigatorSelectorView selectorView);
        void HoverOn(IInvestigatorSelectorView selectorView);
        void HoverOff(IInvestigatorSelectorView selectorView);
        void SetInvestigator(IInvestigatorSelectorView selectorView, ICardView cardView);
    }
}
