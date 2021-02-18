using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Managers
{
    public interface ISelectorsManager
    {
        List<SelectorView> Selectors { get; }
        ISelectorView GetSelectorByInvestigator(string investigatorId);
        ISelectorView GetSelectorVoid();
        void ArrangeSelectors();
    }
}
