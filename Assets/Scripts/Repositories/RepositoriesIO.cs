using System.Collections.Generic;
using System.Runtime.Serialization;
using Arkham.Models;
using Arkham.Config;
using Arkham.Adapters;
using UnityEngine;
using Zenject;

namespace Arkham.Repositories
{
    [DataContract]
    public class RepositoriesIO : IRepositoriesIO
    {
        [Inject] private readonly GameFiles gameFiles;
        [Inject] private readonly ISerializer serializer;
        [Inject] private readonly IFileAdapter fileAdapter;
        [Inject] private readonly IRepositories models;
        [Inject] private readonly ICardInfoRepository infoRepository;

        public void LoadDataCards()
        {
            models.CardInfoList = serializer.CreateDataFromResources<List<CardInfo>>(gameFiles.CardsDataFilePath);
            MultiplyX2CoreSetQuantity();
        }

        private void MultiplyX2CoreSetQuantity() //TODO: Remove it updating datas in JsonFile
        {
            var allCards = infoRepository.CardInfoList.FindAll(card => card.Pack_code == "core"
            && (card.Type_code == "asset"
            || card.Type_code == "event"
            || card.Type_code == "skill"));
            foreach (CardInfo card in allCards)
                card.Quantity *= 2;
        }

        public void SaveProgress() =>
          serializer.SaveFileFromData(models, gameFiles.PlayerProgressFilePath);

        public void LoadProgress()
        {
            if (fileAdapter.FileExist(gameFiles.PlayerProgressFilePath))
                serializer.UpdateDataFromFile(gameFiles.PlayerProgressFilePath, models);
            else
                serializer.UpdateDataFromResources(gameFiles.PlayerProgressDefaultFilePath, models);
        }
    }
}
