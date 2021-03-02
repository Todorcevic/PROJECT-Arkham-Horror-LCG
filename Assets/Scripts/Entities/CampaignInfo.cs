using System.Runtime.Serialization;

namespace Arkham.Entities
{
    [DataContract]
    public class CampaignInfo
    {
        [DataMember] public string Id { get; set; }
        [DataMember] public string State { get; set; }
        public string FirstScenarioId { get; set; }
    }
}
