using NUnit.Framework;
using NSubstitute;
using Arkham.Adapters;
using Arkham.Model;
using Arkham.Services;
using Arkham.Config;

namespace Tests
{
    [TestFixture]
    public class FileCardLoaderTest
    {
        private GameData gameData;

        private void ArrangeAndAct()
        {
            //Arrange  
            GameFiles gamefiles = new GameFiles();
            gameData = new GameData();
            ISerializer serializer = Substitute.For<ISerializer>();
            Card cardMock = new Card { Code = "12345", Name = "TestName" };
            serializer.CreateDataFromResources<Card[]>(default).ReturnsForAnyArgs(new Card[] { cardMock });
            FileCardLoader cardsLoader = new FileCardLoader(gameData, serializer, gamefiles);

            //Act
            cardsLoader.LoadDataCards();
        }

        [Test]
        public void LoadDataCards_WhenCall_AllDataCardsListHaveData()
        {
            ArrangeAndAct();

            //Assert
            CollectionAssert.AllItemsAreNotNull(gameData.AllDataCards, "AllDataCardsList is empty");
        }

        [Test]
        public void LoadDataCards_WhenCall_AllDataCardsDictionaryHaveData()
        {
            ArrangeAndAct();

            //Assert
            CollectionAssert.AllItemsAreNotNull(gameData.AllDataCardsDictionary, "AllDataCardsDictionary is empty");
        }

        [Test]
        public void LoadDataCards_WhenCall_AllDataCardsListCodeIsRight()
        {
            ArrangeAndAct();

            //Assert
            Assert.That(gameData.AllDataCards[0].Code, Is.EqualTo("12345"), "Wrong Code card in List");
        }

        [Test]
        public void LoadDataCards_WhenCall_AllDataCardsListNameIsRight()
        {
            ArrangeAndAct();

            //Assert
            Assert.That(gameData.AllDataCards[0].Name, Is.EqualTo("TestName"), "Wrong Name card in List");
        }

        [Test]
        public void LoadDataCards_WhenCall_AllDataCardsDictionaryKeyCodeIsValueName()
        {
            ArrangeAndAct();

            //Assert
            Assert.That(gameData.AllDataCardsDictionary["12345"].Name, Is.EqualTo("TestName"), "Wrong Code card in Dictionary");
        }

        [TestCase("core", "asset", 6)]
        [TestCase("core", "skill", 6)]
        [TestCase("core", "event", 6)]
        [TestCase("nocore", "event", 3)]
        [TestCase("core", "other", 3)]
        public void LoadDataCards_WhenCall_CoreSetQuantityMultiplyX2(string packCode, string typeCode, int expectedQuantity)
        {
            //Arrange  
            GameFiles gamefiles = new GameFiles();
            gameData = new GameData();
            ISerializer serializer = Substitute.For<ISerializer>();
            Card cardMock = new Card { Code = "12345", Name = "TestName", Quantity = 3, Pack_code = packCode, Type_code = typeCode };
            serializer.CreateDataFromResources<Card[]>(default).ReturnsForAnyArgs(new Card[] { cardMock });
            FileCardLoader cardsLoader = new FileCardLoader(gameData, serializer, gamefiles);

            //Act
            cardsLoader.LoadDataCards();

            //Assert
            Assert.That(gameData.AllDataCards[0].Quantity, Is.EqualTo(expectedQuantity), "Wrong quantity in List");
            Assert.That(gameData.AllDataCardsDictionary["12345"].Quantity, Is.EqualTo(expectedQuantity), "Wrong quantity in Dictionary");
        }
    }
}
