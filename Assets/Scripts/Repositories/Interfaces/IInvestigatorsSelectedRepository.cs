using System;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface IInvestigatorsSelectedRepository
    {
        string InvestigatorFocused { get; set; }
        List<string> InvestigatorsSelectedList { get; }
    }
}
