using Newtonsoft.Json;
using System.Linq;
using UnityEngine;
using Zenject;
using Arkham.Adapters;

namespace Arkham.UI
{
    public class FileCardLoader : IDataCardsLoader
    {
        private readonly string cardsDataFile = GameFiles.RESOURCE_PATH + GameFiles.ALL_CARDS_DATA_FILE;
        private ISerializer serializer;
        private GameData gameData;

        [Inject]
        public void Initialize(GameData gameData, ISerializer serializer)
        {
            this.serializer = serializer;
            this.gameData = gameData;
        }

        public void LoadDataCards()
        {
            gameData.AllDataCards = serializer.CreateDataFromFile<Card[]>(cardsDataFile);
            gameData.AllDataCardsDictionary = gameData.AllDataCards.ToDictionary(card => card.Code);
            MultiplyX2CoreSetQuantity();
        }

        private void MultiplyX2CoreSetQuantity()
        {
            var allData = gameData.AllDataCards.Where(card => card.Pack_code == "core"
            && (card.Type_code == "asset"
            || card.Type_code == "event"
            || card.Type_code == "skill"));
            foreach (Card card in allData)
                card.Quantity *= 2;
        }
    }
}
