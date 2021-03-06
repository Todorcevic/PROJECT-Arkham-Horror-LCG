using System;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface IInvestigatorSelectorRepository
    {
        string CurrentInvestigatorSelected { get; set; }
        List<string> InvestigatorsSelectedList { get; set; }
    }
}
