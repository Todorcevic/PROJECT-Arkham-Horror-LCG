using System;
using System.Collections.Generic;

namespace Arkham.Model
{
    public class CardInGameRepository
    {
        private List<Card> allCardsInGame;

        /*******************************************************************/
        public Card GetCard(Guid guid) => allCardsInGame.Find(card => card.Guid == guid);
    }
}
