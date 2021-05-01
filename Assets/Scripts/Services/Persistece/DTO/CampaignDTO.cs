using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Arkham.Services
{
    [DataContract]
    public class CampaignDTO
    {
        [DataMember] public string Id { get; set; }
        [DataMember] public string State { get; set; }
        [DataMember] public string Firstscenario { get; set; }
    }
}
