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
        void Init();
        void SelectSelector(IInvestigatorSelectorView selectorView);
        void AddInvestigator(ICardComponent investigator);
        void RemoveSelector(IInvestigatorSelectorView selector);
    }
}
