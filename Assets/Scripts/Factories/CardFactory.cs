using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arkham.Model;
using Arkham.UI;

namespace Arkham.Factories
{
    public class CardFactory : ICardFactory
    {
        private readonly CardVComponent cardVPrefab;
        private readonly CardHComponent cardHPrefab;
        private readonly GameData gameData;

        public CardFactory(CardVComponent cardVPrefab, CardHComponent cardHPrefab, GameData gameData)
        {
            this.cardVPrefab = cardVPrefab;
            this.cardHPrefab = cardHPrefab;
            this.gameData = gameData;
        }

        public void BuildCards()
        {

        }
    }
}
