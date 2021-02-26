using System;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface IInvestigatorSelectorRepository
    {
        List<string> InvestigatorsSelectedList { get; set; }
    }
}
