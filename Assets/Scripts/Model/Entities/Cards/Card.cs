using Zenject;

namespace Arkham.Model
{
    public class Card
    {
        [Inject] protected readonly PlayersRepository playersRepository;
        [Inject] protected readonly CardsInfoRepository cardsInfoRepository;
        [Inject] protected readonly ZonesRepository zonesRepository;

        public string Id { get; private set; }
        public CardInfo Info => cardsInfoRepository.GetInfo(Id);
        public Zone CurrentZone => zonesRepository.GetZoneWithThisCard(this);
        public Player Owner => playersRepository.GetPlayerContainThisCard(this);
        public Investigator Control { get; set; }
        public bool IsScenarioCard => Owner is null;
        public Zone CardZone { get; } = new Zone();

        /*******************************************************************/
        public void Init(string cardId)
        {
            Id = cardId;
        }

        /*******************************************************************/
        public void EnterInThisZone(Zone zone)
        {
            CurrentZone?.ExitThisCard(this);
            zone.EnterThisCard(this);
        }
    }
}
