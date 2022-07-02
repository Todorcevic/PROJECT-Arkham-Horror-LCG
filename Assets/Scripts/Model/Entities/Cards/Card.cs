using Zenject;

namespace Arkham.Model
{
    public class Card
    {
        [Inject] protected readonly CardsInfoRepository cardsInfoRepository;

        public string Id { get; private set; }
        public CardInfo Info => cardsInfoRepository.GetInfo(Id);
        public Zone CurrentZone { get; set; }
        public Player Owner { get; set; }
        public Investigator Control { get; set; }
        public bool IsScenarioCard => Owner is null;
        public Zone CardZone { get; } = new Zone();

        /*******************************************************************/
        public void Init(string cardId)
        {
            Id = cardId;
        }

        /*******************************************************************/
    }
}
