using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface IInvestigatorSelectorLoader
    {
        List<string> InvestigatorsSelectedList { get; set; }
    }
}
