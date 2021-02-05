using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Arkham.Models
{
    [DataContract]
    public class Investigator : IEntity
    {
        string IEntity.Identity => Id;
        [DataMember] public string Id { get; set; }
        [DataMember] public int PhysicTrauma { get; set; }
        [DataMember] public int MentalTrauma { get; set; }
        [DataMember] public int Xp { get; set; }
        [DataMember] public List<string> Deck { get; set; }
        [DataMember] public List<string> MandatoryCards { get; set; }
        public List<string> FullDeck => MandatoryCards.Concat(Deck).ToList();
    }
}
