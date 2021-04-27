using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Arkham.Entities
{
    [DataContract]
    public class InvestigatorInfo
    {
        [DataMember] public string Id { get; set; }
        [DataMember] public int PhysicTrauma { get; set; }
        [DataMember] public int MentalTrauma { get; set; }
        [DataMember] public int Xp { get; set; }
        [DataMember] public bool IsPlaying { get; set; }
        [DataMember] public bool IsRetired { get; set; }
        [DataMember] public List<string> Deck { get; set; } = new List<string>();
        [DataMember] public List<string> MandatoryCards { get; set; } = new List<string>();
        public CardInfo Info { get; set; }
        public List<string> FullDeck => MandatoryCards.Concat(Deck).ToList();
        public DeckBuildingRules DeckBuilding { get; set; }
        public bool SelectionIsFull => AmountCardsSelected >= DeckSize;
        public int DeckSize => DeckBuilding.DeckSize;
        public int AmountCardsSelected => Deck.Count;
        public bool ISKilled => PhysicTrauma >= (Info.Health ?? 0);
        public bool ISInsane => MentalTrauma >= (Info.Sanity ?? 0);
        public bool IsEliminated => ISKilled || ISInsane || IsRetired;


        /*******************************************************************/
        public int GetAmountOfThisCardInDeck(string cardId) => FullDeck.FindAll(id => id == cardId).Count;
    }
}
