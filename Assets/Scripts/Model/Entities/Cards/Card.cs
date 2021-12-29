using System;

namespace Arkham.Model
{
    public class Card
    {
        public Guid Guid { get; } = Guid.NewGuid();
        public string Id => Info.Id;
        public CardInfo Info { get; private set; }
        public Zone CurrentZone { get; set; }
        public Investigator Owner { get; set; }
        public Investigator Control { get; set; }

        /*******************************************************************/
        public void CreateWithThisCard(CardInfo cardInfo)
        {
            Info = cardInfo;
        }

        /*******************************************************************/
        protected virtual void BeginGameAction(GameAction gameAction) { }

        protected virtual void EndGameAction(GameAction gameAction) { }
    }
}
