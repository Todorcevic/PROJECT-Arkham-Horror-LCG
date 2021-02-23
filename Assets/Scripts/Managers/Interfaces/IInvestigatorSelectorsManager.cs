using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Managers
{
    public interface IInvestigatorSelectorsManager
    {
        List<IInvestigatorSelectorView> Selectors { get; }
        IInvestigatorSelectorView GetSelectorByInvestigator(string investigatorId);
        IInvestigatorSelectorView GetSelectorVoid();
        void ArrangeSelectors();
    }
}
