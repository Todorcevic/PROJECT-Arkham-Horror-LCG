namespace Arkham.Model
{
    public class Card
    {
        public string Id { get; private set; }
        public CardInfo Info { get; private set; }
        public Zone CurrentZone { get; set; }
        public Player Owner { get; set; }
        public Investigator Control { get; set; }
        public bool IsScenarioCard => Owner is null;
        public Zone CardZone { get; } = new Zone();

        /*******************************************************************/
        public void Init(string cardId, CardInfo cardInfo)
        {
            Id = cardId;
            Info = cardInfo;
        }

        /*******************************************************************/
    }
}
