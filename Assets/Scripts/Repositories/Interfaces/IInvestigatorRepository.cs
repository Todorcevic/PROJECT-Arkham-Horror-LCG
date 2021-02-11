using Arkham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Repositories
{
    public interface IInvestigatorRepository
    {
        Dictionary<string, Investigator> AllInvestigators { get; }
        List<Investigator> InvestigatorsList { get; }
    }
}
