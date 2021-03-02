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
        List<string> InvestigatorsSelectedList { get; }
        string InvestigatorSelected { get; }
        string LeadInvestigator { get; }
        bool SelectionIsFull { get; }
        bool SelectionIsNotFull { get; }
        void SelectInvestigator(string investigatorId);
        void AddInvestigator(string investigatorId);
        void RemoveInvestigator(string investigatorId);
        int AmountSelectedOfThisCard(string cardId);
        void SelectLeadInvestigator();
    }
}
