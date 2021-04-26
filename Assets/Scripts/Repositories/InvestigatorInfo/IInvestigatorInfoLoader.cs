using Arkham.Entities;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface IInvestigatorInfoLoader
    {
        List<InvestigatorInfo> InvestigatorsList { get; set; }
    }
}
