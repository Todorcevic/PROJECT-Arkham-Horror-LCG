using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Interactors
{
    public interface IInvestigatorSelectorInteractor
    {
        event Action<string> InvestigatorSelectedChanged;
        event Action<string> InvestigatorAdded;
        event Action<string> InvestigatorRemoved;
        string InvestigatorFocused { get; set; }
        List<string> InvestigatorsSelectedList { get; set; }
        void SelectInvestigator(string investigatorId);
        void AddInvestigator(string investigatorId);
        void RemoveInvestigator(string investigatorId);
    }
}
