using System.Collections.Generic;

namespace Arkham.Model
{
    public class NullPlayer : Player
    {
        public override List<Card> Deck => new List<Card>();
    }
}
