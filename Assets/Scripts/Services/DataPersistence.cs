using System.Collections.Generic;
using Arkham.Entities;
using Arkham.Config;
using Arkham.Repositories;
using Zenject;
using UnityEngine;

namespace Arkham.Services
{
    public class DataPersistence : IDataPersistence, IInitializable
    {
        [Inject] private readonly GameFiles gameFiles;
        [Inject] private readonly IRepository repository;
        [Inject] private readonly ISerializer serializer;
        [Inject] private readonly IFileAdapter fileAdapter;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            LoadDataCards();
            LoadProgress();
        }

        /*******************************************************************/
        public void LoadDataCards() =>
            repository.CardInfoList = serializer.CreateDataFromResources<List<CardInfo>>(gameFiles.CardsDataFilePath);

        public void SaveProgress() => serializer.SaveFileFromData(repository, gameFiles.PlayerProgressFilePath);

        public void LoadProgress()
        {
            if (fileAdapter.FileExist(gameFiles.PlayerProgressFilePath))
                serializer.UpdateDataFromFile(gameFiles.PlayerProgressFilePath, repository);
            else
                serializer.UpdateDataFromResources(gameFiles.PlayerProgressDefaultFilePath, repository);
        }
    }
}
