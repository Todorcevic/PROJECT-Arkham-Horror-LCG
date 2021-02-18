using System;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface IInvestigatorsSelectedRepository
    {
        List<string> InvestigatorsSelectedList { get; }
    }
}
