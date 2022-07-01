using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Arkham.Model
{
    public class Player
    {
        private List<Card> deck = new List<Card>();

        public InvestigatorCard InvestigatorCard { get; }
        public Zone InvestigatorZone { get; } = new Zone();
        public Zone HandZone { get; } = new Zone();
        public Zone DeckZone { get; } = new Zone();
        public Zone DiscardZone { get; } = new Zone();
        public Zone AssetZone { get; } = new Zone();
        public Zone ThreatZone { get; } = new Zone();
        public ReadOnlyCollection<Card> Deck => deck.AsReadOnly();

        /*******************************************************************/
        public Player(InvestigatorCard investigatorCard)
        {
            InvestigatorCard = investigatorCard;
        }

        public void AddCardInDeck(Card card) => deck.Add(card);

        public void RemoveCardInDeck(Card card) => deck.Remove(card);
    }
}
