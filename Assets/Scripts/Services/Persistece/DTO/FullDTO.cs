using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Arkham.Services
{
    [DataContract]
    public class FullDTO
    {
        [DataMember] public string CurrentScenario { get; set; }
        [DataMember] public List<CampaignDTO> CampaignsList { get; set; } = new List<CampaignDTO>();
        [DataMember] public List<InvestigatorDTO> InvestigatorsList { get; set; } = new List<InvestigatorDTO>();
        [DataMember] public List<string> InvestigatorsSelectedList { get; set; } = new List<string>();
        [DataMember] public List<string> UnlockCards { get; set; } = new List<string>();
    }
}
