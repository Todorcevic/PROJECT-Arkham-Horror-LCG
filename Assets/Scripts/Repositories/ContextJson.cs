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
        private readonly IBuildRepository repository;
        private readonly ICardInfoRepository infoRepository;

        public ContextJson(GameFiles gameFiles, ISerializer serializer, IFileAdapter fileAdapter, IBuildRepository repository, ICardInfoRepository infoRepository)
        {
            this.gameFiles = gameFiles;
            this.serializer = serializer;
            this.fileAdapter = fileAdapter;
            this.repository = repository;
            this.infoRepository = infoRepository;
        }

        public void LoadDataCards()
        {
            repository.CardInfoList = serializer.CreateDataFromResources<List<CardInfo>>(gameFiles.CardsDataFilePath);
            MultiplyX2CoreSetQuantity();
        }

        private void MultiplyX2CoreSetQuantity()
        {
            var allCards = infoRepository.CardInfoList.FindAll(card => card.Pack_code == "core"
            && (card.Type_code == "asset"
            || card.Type_code == "event"
            || card.Type_code == "skill"));
            foreach (CardInfo card in allCards)
                card.Quantity *= 2;
        }

        public void SaveProgress() =>
          serializer.SaveFileFromData(repository, gameFiles.PlayerProgressFilePath);

        public void LoadProgress()
        {
            if (fileAdapter.FileExist(gameFiles.PlayerProgressFilePath))
                serializer.UpdateDataFromFile(gameFiles.PlayerProgressFilePath, repository);
            else
                serializer.UpdateDataFromResources(gameFiles.PlayerProgressDefaultFilePath, repository);
        }
    }
}
