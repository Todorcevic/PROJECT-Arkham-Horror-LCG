using System;
using Zenject;

namespace Arkham.Model
{
    public class Card
    {
        [Inject] protected readonly ZonesRepository zonesRepository;
        [Inject] protected readonly CardsInGameRepository cardsInGameRepository;
        [Inject] protected readonly PlayersRepository playersRepository;

        public Guid Guid { get; } = Guid.NewGuid();
        public string Id => Info.Id;
        public CardInfo Info { get; private set; }
        public Zone CurrentZone => zonesRepository.GetZoneWithThisCard(this);
        public Player Owner => playersRepository.GetPlayerContainThisCard(this);
        public Investigator Control { get; set; }
        public bool IsScenarioCard => Owner is null;
        public Zone CardZone { get; } = new Zone(ZoneType.Card);

        /*******************************************************************/
        public void CreateWithThisCard(CardInfo cardInfo)
        {
            Info = cardInfo;
            cardsInGameRepository.Add(this);
        }

        /*******************************************************************/
        protected virtual void BeginGameAction(GameAction gameAction) { }

        protected virtual void EndGameAction(GameAction gameAction) { }
    }
}
