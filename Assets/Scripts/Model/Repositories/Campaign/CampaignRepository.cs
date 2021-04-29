using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;


namespace Arkham.Model
{
    [DataContract]
    public class CampaignRepository
    {
        [DataMember] public string CurrentScenario { get; set; }
        [DataMember] public List<CampaignInfo> CampaignsList { get; set; }
        public IEnumerable<string> CampaignsId => CampaignsList.Select(c => c.Id);

        /*******************************************************************/
        public CampaignInfo Get(string campaignId) => CampaignsList.Find(c => c.Id == campaignId);
    }
}
