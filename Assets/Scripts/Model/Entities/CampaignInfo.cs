using System.Runtime.Serialization;

namespace Arkham.Model
{
    [DataContract]
    public class CampaignInfo
    {
        [DataMember] public string Id { get; set; }
        [DataMember] public string State { get; set; }
        [DataMember] public string FirstScenario { get; set; }
    }
}
