using System.Linq;
using Arkham.Adapters;
using Arkham.Config;
using Arkham.Model;

namespace Arkham.Services
{
    public class FileCardLoader : IDataCardsLoader
    {
        private readonly ISerializer serializer;
        private readonly GameData gameData;
        private readonly GameFiles gamefiles;

        public FileCardLoader(GameData gameData, ISerializer serializer, GameFiles gamefiles)
        {
            this.serializer = serializer;
            this.gameData = gameData;
            this.gamefiles = gamefiles;
        }

        public void LoadDataCards()
        {
            gameData.AllDataCards = serializer.CreateDataFromResources<Card[]>(gamefiles.CardsDataFilePath);
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
