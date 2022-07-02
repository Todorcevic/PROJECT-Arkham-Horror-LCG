using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Arkham.Model
{
    public class Player
    {
        [Inject] private readonly CardsInGameRepository cardsInGameRepository;

        public InvestigatorCard InvestigatorCard => Deck.OfType<InvestigatorCard>().Single();
        public Zone InvestigatorZone { get; } = new Zone();
        public Zone HandZone { get; } = new Zone();
        public Zone DeckZone { get; } = new Zone();
        public Zone DiscardZone { get; } = new Zone();
        public Zone AssetZone { get; } = new Zone();
        public Zone ThreatZone { get; } = new Zone();
        public List<Card> Deck => cardsInGameRepository.GetAllCardsOfThisPlayer(this);

        /*******************************************************************/
    }
}
