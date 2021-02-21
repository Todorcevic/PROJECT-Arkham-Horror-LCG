using Arkham.Models;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface IRepositories
    {
        List<CardInfo> CardInfoList { set; }
        List<InvestigatorInfo> InvestigatorsList { set; }
    }
}
