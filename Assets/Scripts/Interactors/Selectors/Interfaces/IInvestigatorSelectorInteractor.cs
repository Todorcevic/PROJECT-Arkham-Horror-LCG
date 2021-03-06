using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Interactors
{
    public interface IInvestigatorSelectorInteractor
    {
        string LeadInvestigator { get; }
        bool SelectionIsFull { get; }
        bool CanThisCardBeSelected(string cardId);
    }
}
