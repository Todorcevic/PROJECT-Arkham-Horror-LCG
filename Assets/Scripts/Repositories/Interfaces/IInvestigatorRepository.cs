using Arkham.Models;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface IInvestigatorRepository
    {
        List<InvestigatorInfo> InvestigatorsList { get; set; }
    }
}
