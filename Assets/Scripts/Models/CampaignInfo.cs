using System.Runtime.Serialization;

namespace Arkham.Models
{
    [DataContract]
    public class CampaignInfo
    {
        [DataMember] public string Id { get; set; }
        [DataMember] public string State { get; set; }
        public bool IsOpen { get; set; }
        public string FirstScenarioId { get; set; }
    }
}
