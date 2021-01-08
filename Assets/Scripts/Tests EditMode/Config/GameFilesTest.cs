using Arkham.Config;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class GameFilesTest
    {
        private GameFiles gameFiles;

        [SetUp]
        public void CommonInstall()
        {
            gameFiles = new GameFiles();
        }

        [Test]
        public void AllCardsData_File_Exist()
        {
            Assert.That(Resources.Load<TextAsset>(gameFiles.CardsDataFilePath),
                Is.Not.Null, "File not found on " + gameFiles.CardsDataFilePath);
        }

        [Test]
        public void PlayerProgressDefault_File_Exist()
        {
            Assert.That(Resources.Load<TextAsset>(gameFiles.PlayerProgressDefaultFilePath),
                Is.Not.Null, "File not found on " + gameFiles.PlayerProgressDefaultFilePath);
        }
    }
}
