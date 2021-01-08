using NUnit.Framework;
using Arkham.Services;
using Arkham.Adapters;
using Arkham.Model;
using Arkham.Config;
using NSubstitute;

namespace Tests
{
    [TestFixture]
    public class PlayerProgressIOTest
    {
        [Test]
        public void SaveProgress_WhenCall_FileCreated()
        {
            //Arrange
            GameFiles gameFiles = new GameFiles();
            PlayerData playerData = new PlayerData();
            ISerializer serializer = Substitute.For<ISerializer>();
            IFileAdapter fileAdapter = Substitute.For<IFileAdapter>();
            PlayerProgressIO playerProgressIO = new PlayerProgressIO(serializer, fileAdapter, playerData, gameFiles);

            //Act
            playerProgressIO.SaveProgress();

            //Assert
            serializer.Received().SaveFileFromData(playerData, gameFiles.PlayerProgressFilePath);
        }

        [Test]
        public void LoadProgress_WhenCallAndsaveFileNotExist_PlayerDataModified()
        {
            //Arrange
            GameFiles gameFiles = new GameFiles();
            PlayerData playerData = new PlayerData();
            ISerializer serializer = Substitute.For<ISerializer>();
            IFileAdapter fileAdapter = Substitute.For<IFileAdapter>();
            fileAdapter.FileExist(default).ReturnsForAnyArgs(false);
            PlayerProgressIO playerProgressIO = new PlayerProgressIO(serializer, fileAdapter, playerData, gameFiles);

            //Act
            playerProgressIO.LoadProgress();

            //Assert
            serializer.Received().UpdateDataFromResources(gameFiles.PlayerProgressDefaultFilePath, playerData);
        }

        [Test]
        public void LoadProgress_WhenCallAndSaveFileExist_PlayerDataModified()
        {
            //Arrange
            GameFiles gameFiles = new GameFiles();
            PlayerData playerData = new PlayerData();
            ISerializer serializer = Substitute.For<ISerializer>();
            IFileAdapter fileAdapter = Substitute.For<IFileAdapter>();
            fileAdapter.FileExist(default).ReturnsForAnyArgs(true);
            PlayerProgressIO playerProgressIO = new PlayerProgressIO(serializer, fileAdapter, playerData, gameFiles);

            //Act
            playerProgressIO.LoadProgress();

            //Assert
            serializer.Received().UpdateDataFromFile(gameFiles.PlayerProgressFilePath, playerData);
        }
    }
}
