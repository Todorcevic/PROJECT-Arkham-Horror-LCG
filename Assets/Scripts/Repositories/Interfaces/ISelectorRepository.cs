using System;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ISelectorRepository
    {
        List<string> InvestigatorsSelectedList { get; set; }
    }
}
