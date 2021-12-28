using System;

namespace Arkham.Model
{
    public class Card
    {
        public Guid Guid { get; } = Guid.NewGuid();
        public string Id => Info.Id;
        public CardInfo Info { get; protected set; }
        public CardLogic Logic { get; protected set; }
        public Zone CurrentZone { get; private set; }

        /*******************************************************************/
        public void MoveTo(Zone zone)
        {
            CurrentZone?.ExitThisCard(this);
            zone.EnterThisCard(this);
            CurrentZone = zone;
        }
    }
}
