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
    public class ContextJson : IContext
    {
        [Inject] private readonly GameFiles gameFiles;
        [Inject] private readonly ISerializer serializer;
        [Inject] private readonly IFileAdapter fileAdapter;
        [Inject] private readonly IBuildRepository repository;
        [Inject] private readonly ICardInfoRepository infoRepository;

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
