using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface IInvestigatorSelectorInfo
    {
        bool IsSelectionFull { get; }
        string Lead { get; }
        string CurrentInvestigatorSelected { get; }
        int AmontInvestigatorsSelected { get; }
        IEnumerable<string> AllInvestigatorsSelected { get; }
        bool Contains(string investigatorId);
        int AmountSelectedOfThisInvestigator(string investigatorId);
    }
}
