using System.Collections.Generic;
using System.Runtime.Serialization;
using Arkham.Models;
using Arkham.Config;
using Arkham.Adapters;
using UnityEngine;

namespace Arkham.Repositories
{
    [DataContract]
    public class ContextJson : IContext
    {
        private readonly GameFiles gameFiles;
        private readonly ISerializer serializer;
        private readonly IFileAdapter fileAdapter;
        private readonly Repository allData;

        public ContextJson(GameFiles gameFiles, ISerializer serializer, IFileAdapter fileAdapter, Repository allData)
        {
            this.gameFiles = gameFiles;
            this.serializer = serializer;
            this.fileAdapter = fileAdapter;
            this.allData = allData;
        }

        void IContext.LoadDataCards()
        {
            allData.CardInfoList = serializer.CreateDataFromResources<List<CardInfo>>(gameFiles.CardsDataFilePath);
            MultiplyX2CoreSetQuantity();
        }

        private void MultiplyX2CoreSetQuantity()
        {
            var allCards = allData.CardInfoList.FindAll(card => card.Pack_code == "core"
            && (card.Type_code == "asset"
            || card.Type_code == "event"
            || card.Type_code == "skill"));
            foreach (CardInfo card in allCards)
                card.Quantity *= 2;
        }

        void IContext.SaveProgress() =>
          serializer.SaveFileFromData(allData, gameFiles.PlayerProgressFilePath);

        void IContext.LoadProgress()
        {
            if (fileAdapter.FileExist(gameFiles.PlayerProgressFilePath))
                serializer.UpdateDataFromFile(gameFiles.PlayerProgressFilePath, allData);
            else
                serializer.UpdateDataFromResources(gameFiles.PlayerProgressDefaultFilePath, allData);
        }
    }
}
