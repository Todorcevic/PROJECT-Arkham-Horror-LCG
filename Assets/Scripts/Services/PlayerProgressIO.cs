using Arkham.Adapters;
using Arkham.Model;
using Arkham.Config;
using System.IO;
using UnityEngine;

namespace Arkham.Services
{
    public class PlayerProgressIO : ILoadSaveProgress
    {
        private ISerializer serializer;
        private IFileAdapter fileAdapter;
        private PlayerData playerData;
        private GameFiles gameFiles;

        public PlayerProgressIO(ISerializer serializer, IFileAdapter fileAdapter, PlayerData playerData, GameFiles gameFiles)
        {
            this.serializer = serializer;
            this.fileAdapter = fileAdapter;
            this.playerData = playerData;
            this.gameFiles = gameFiles;
        }

        public void SaveProgress() =>
            serializer.SaveFileFromData(playerData, gameFiles.PlayerProgressFilePath);

        public void LoadProgress()
        {
            if (fileAdapter.FileExist(gameFiles.PlayerProgressFilePath))
                serializer.UpdateDataFromFile(gameFiles.PlayerProgressFilePath, playerData);
            else
                serializer.UpdateDataFromResources(gameFiles.PlayerProgressDefaultFilePath, playerData);
        }
    }
}
