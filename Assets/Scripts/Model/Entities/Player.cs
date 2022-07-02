using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zenject;

namespace Arkham.Model
{
    public class Player
    {
        private readonly CardsInGameRepository cardsInGameRepository;

        public InvestigatorCard InvestigatorCard { get; }
        public Zone InvestigatorZone { get; } = new Zone();
        public Zone HandZone { get; } = new Zone();
        public Zone DeckZone { get; } = new Zone();
        public Zone DiscardZone { get; } = new Zone();
        public Zone AssetZone { get; } = new Zone();
        public Zone ThreatZone { get; } = new Zone();
        public List<Card> Deck => cardsInGameRepository.GetAllCardsOfThisPlayer(this);

        /*******************************************************************/
        public Player(InvestigatorCard investigatorCard, CardsInGameRepository cardsInGameRepository)
        {
            InvestigatorCard = investigatorCard;
            this.cardsInGameRepository = cardsInGameRepository;
        }
    }
}
