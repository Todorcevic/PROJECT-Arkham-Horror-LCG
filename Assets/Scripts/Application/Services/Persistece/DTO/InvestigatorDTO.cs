using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Arkham.Application
{
    [DataContract]
    public class InvestigatorDTO
    {
        [DataMember] public string Id { get; set; }
        [DataMember] public int PhysicTrauma { get; set; }
        [DataMember] public int MentalTrauma { get; set; }
        [DataMember] public int Xp { get; set; }
        [DataMember] public bool IsPlaying { get; set; }
        [DataMember] public bool IsRetired { get; set; }
        [DataMember] public List<string> Deck { get; set; } = new List<string>();
        [DataMember] public List<string> MandatoryCards { get; set; } = new List<string>();
    }
}
