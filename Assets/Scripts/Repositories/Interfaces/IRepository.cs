using Arkham.Entities;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface IRepository
    {
        List<CampaignInfo> CampaignsList { get; set; }
        List<CardInfo> CardInfoList { get; set; }
        Dictionary<string, CardInfo> CardInfoDict { set; }
        List<InvestigatorInfo> InvestigatorsList { get; set; }
        List<string> InvestigatorsSelectedList { get; set; }
    }
}
