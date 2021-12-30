using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Arkham.Model
{
    public class Player
    {
        private List<Card> deck = new List<Card>();

        public Investigator Investigator { get; }
        public InvestigatorCard InvestigatorCard { get; }
        public Zone InvestigatorZone { get; } = new Zone(ZoneType.Investigator);
        public Zone HandZone { get; } = new Zone(ZoneType.Hand);
        public Zone DeckZone { get; } = new Zone(ZoneType.InvestigatorDeck);
        public Zone DiscardZone { get; } = new Zone(ZoneType.InvestigatorDiscard);
        public Zone AssetZone { get; } = new Zone(ZoneType.Assets);
        public Zone ThreatZone { get; } = new Zone(ZoneType.Threats);
        public ReadOnlyCollection<Card> Deck => deck.AsReadOnly();

        /*******************************************************************/
        public Player(Investigator investigator, InvestigatorCard investigatorCard)
        {
            Investigator = investigator;
            InvestigatorCard = investigatorCard;
        }

        public void AddCardInDeck(Card card) => deck.Add(card);

        public void RemoveCardInDeck(Card card) => deck.Remove(card);
    }
}
