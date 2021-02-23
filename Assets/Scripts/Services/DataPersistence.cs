using System.Collections.Generic;
using System.Runtime.Serialization;
using Arkham.Models;
using Arkham.Config;
using Arkham.Adapters;
using Zenject;
using Arkham.Repositories;

namespace Arkham.Services
{
    [DataContract]
    public class DataPersistence : IDataPersistence
    {
        [Inject] private readonly GameFiles gameFiles;
        [Inject] private readonly ISerializer serializer;
        [Inject] private readonly IFileAdapter fileAdapter;
        [Inject] private readonly IRepositories models;
        [Inject] private readonly ICampaignRepository campaignRepository;
        [Inject] private readonly ISelectorRepository selectorRepository;

        public void LoadDataCards() => models.CardInfoList = serializer.CreateDataFromResources<List<CardInfo>>(gameFiles.CardsDataFilePath);

        public void SaveProgress()
        {
            serializer.SaveFileFromData(models, gameFiles.PlayerProgressFilePath);
            serializer.SaveFileFromData(campaignRepository, gameFiles.PlayerProgressFilePath);
            serializer.SaveFileFromData(selectorRepository, gameFiles.PlayerProgressFilePath);
        }

        public void LoadProgress()
        {
            if (fileAdapter.FileExist(gameFiles.PlayerProgressFilePath))
            {
                serializer.UpdateDataFromFile(gameFiles.PlayerProgressFilePath, models);
                serializer.UpdateDataFromFile(gameFiles.PlayerProgressFilePath, campaignRepository);
                serializer.UpdateDataFromFile(gameFiles.PlayerProgressFilePath, selectorRepository);
            }
            else
            {
                serializer.UpdateDataFromResources(gameFiles.PlayerProgressDefaultFilePath, models);
                serializer.UpdateDataFromResources(gameFiles.PlayerProgressDefaultFilePath, campaignRepository);
                serializer.UpdateDataFromResources(gameFiles.PlayerProgressDefaultFilePath, selectorRepository);
            }
        }
    }
}
