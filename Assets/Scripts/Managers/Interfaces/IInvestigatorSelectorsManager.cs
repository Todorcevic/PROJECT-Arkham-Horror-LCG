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
        void AddInvestigator(CardView investigator);
        void RemoveSelector(InvestigatorSelectorView selector);
    }
}
