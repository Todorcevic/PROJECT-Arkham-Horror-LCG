using System;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ISelectorRepository
    {
        string InvestigatorFocused { get; set; }
        List<string> InvestigatorsSelectedList { get; set; }
    }
}
