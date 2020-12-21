using NUnit.Framework;
using Arkham.Adapters;
using Arkham.UI;
using System;

namespace Tests
{
    public class JsonNewtonsoftAdapterTest
    {
        [OneTimeSetUp]
        public void ClassInit()
        {

        }

        [SetUp]
        public void TestInit()
        {

        }

        [Test]
        public void CreateDataFromFile_WhenValidPath_ReturnObject()
        {
            //Arrange
            const string path = GameFiles.RESOURCE_PATH + GameFiles.ALL_CARDS_DATA_FILE;
            Type expected = typeof(Card[]);
            JsonNewtonsoftAdapter serializer = new JsonNewtonsoftAdapter();

            //Act
            var result = serializer.CreateDataFromFile<Card[]>(path);

            //Assert
            Assert.That(result, Is.InstanceOf(expected), "Object not returned");
        }

        [Test]
        public void CreateDataFromFile_WhenInvalidPath_ThrowExeption()
        {
            //Arrange
            const string path = "";
            JsonNewtonsoftAdapter serializer = new JsonNewtonsoftAdapter();

            //Act

            //Assert
            Assert.Throws<NullReferenceException>(() => serializer.CreateDataFromFile<Card[]>(path));
        }

        [TearDown]
        public void TestCleanUp()
        {

        }

        [OneTimeTearDown]
        public void ClassCleanUp()
        {

        }
    }
}
