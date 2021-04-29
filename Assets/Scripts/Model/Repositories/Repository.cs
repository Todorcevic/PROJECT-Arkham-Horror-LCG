using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Arkham.Model
{
    [DataContract]
    public class Repository
    {
        [DataMember] public string CurrentScenario { get; set; }
        [DataMember] public List<CampaignInfo> CampaignsList { get; set; }
        [DataMember] public List<InvestigatorInfo> InvestigatorsList { get; set; }
        [DataMember] public List<string> InvestigatorsSelectedList { get; set; }
        [DataMember] public List<string> UnlockCards { get; set; } = new List<string>();
    }
}
