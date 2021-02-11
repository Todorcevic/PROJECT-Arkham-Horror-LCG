using Arkham.Models;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface IBuildRepository
    {
        string CurrentScenario { set; }
        List<CardInfo> CardInfoList { set; }
        List<string> InvestigatorsSelectedList { set; }
        List<Investigator> InvestigatorsList { set; }
        List<Campaign> CampaignsList { set; }
    }
}
